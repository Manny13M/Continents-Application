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
    /// Interaction logic for AddCountry.xaml
    /// </summary>
    public partial class AddCountry : Window
    {
        private MainWindow mainWindow;

        public AddCountry(MainWindow mainWindow)
        {
            InitializeComponent();
            LoadCmbContinents();
            this.mainWindow = mainWindow;
        }

        public void LoadCmbContinents()
        {
            using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
            {
                string query = "SELECT ContinentName FROM Continent";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> continentNames = new List<string>();
                while (reader.Read())
                {
                    string continentName = reader["ContinentName"].ToString();
                    continentNames.Add(continentName);
                }

                cmbBoxContinents.ItemsSource = continentNames;
            }
        }

        private void btnAddCountryToDB_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBoxContinents.SelectedIndex != -1 &&
                !string.IsNullOrEmpty(txtCountryName.Text.ToString()) &&
                !string.IsNullOrEmpty(txtCountryLanguage.Text.ToString()) &&
                !string.IsNullOrEmpty(txtCountryCurrency.Text.ToString()))
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
                {
                    conn.Open();

                    string queryContinent = "SELECT ContinentId FROM Continent WHERE ContinentName = @ContinentName";

                    SqlCommand cmdContinent = new SqlCommand(queryContinent, conn);
                    cmdContinent.Parameters.AddWithValue("ContinentName", cmbBoxContinents.SelectedItem.ToString());

                    int continentID = (int)cmdContinent.ExecuteScalar();


                    string query = "INSERT INTO Country (CountryName, Language, Currency, ContinentId) VALUES (@CountryName, @Language, @Currency, @ContinentId)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("CountryName", txtCountryName.Text.ToString());
                    cmd.Parameters.AddWithValue("Language", txtCountryLanguage.Text.ToString());
                    cmd.Parameters.AddWithValue("Currency", txtCountryCurrency.Text.ToString());
                    cmd.Parameters.AddWithValue("ContinentId", continentID);


                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        MessageBox.Show("Country inserted");
                        txtCountryName.Text = "";
                        txtCountryLanguage.Text = "";
                        txtCountryCurrency.Text = "";
                        cmbBoxContinents.SelectedIndex = -1;
                    }
                    else
                        MessageBox.Show("Country not inserted");
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
