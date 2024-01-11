using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace A3ManuelMartinez
{
    /// <summary>
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Window
    {

        private MainWindow mainWindow;
        public AddCity(MainWindow mainWindow)
        {
            InitializeComponent();
            LoadCmbCountries();
            this.mainWindow = mainWindow;
        }

        public void LoadCmbCountries()
        {
            using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
            {
                string query = "SELECT CountryName FROM Country";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> countryNames = new List<string>();
                while (reader.Read())
                {
                    string countryName = reader["CountryName"].ToString();
                    countryNames.Add(countryName);
                }

                cmbBoxCountries.ItemsSource = countryNames;
            }
        }

        private void btnAddCityToDB_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBoxCountries.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(txtCityName.Text.ToString()) &&
                !string.IsNullOrEmpty(txtCityPopulation.Text.ToString()))
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
                {
                    conn.Open();

                    string queryCountry = "SELECT CountryId FROM Country WHERE CountryName = @CountryName";

                    SqlCommand cmdContinent = new SqlCommand(queryCountry, conn);
                    cmdContinent.Parameters.AddWithValue("CountryName", cmbBoxCountries.SelectedItem.ToString());

                    int countryID = (int)cmdContinent.ExecuteScalar();


                    string query = "INSERT INTO City (CityName, Population, IsCapital, CountryId) VALUES (@CityName, @Population, @IsCapital, @CountryId)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("CityName", txtCityName.Text.ToString());
                    cmd.Parameters.AddWithValue("Population", txtCityPopulation.Text.ToString());
                    cmd.Parameters.AddWithValue("IsCapital", isCapital.IsChecked);
                    cmd.Parameters.AddWithValue("CountryId", countryID);


                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        MessageBox.Show("City inserted");
                        txtCityName.Text = "";
                        txtCityPopulation.Text = "";
                        cmbBoxCountries.SelectedIndex = -1;
                        isCapital.IsChecked = false;
                    }
                    else
                        MessageBox.Show("City not inserted");
                }
            }
            else
            {
                MessageBox.Show("Please ensure all fields are properly filled.");
            }
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.ClearFields();
            mainWindow.lstBoxCountries.ItemsSource = null;
            mainWindow.cmbBoxContinents.SelectedIndex = -1;
            mainWindow.LoadCmbContinents();
            this.Close();
        }
    }
}
