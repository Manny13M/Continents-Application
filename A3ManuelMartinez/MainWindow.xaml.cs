using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace A3ManuelMartinez
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCmbContinents();
        }

        public void ClearFields() 
        {
            //Clearing data fields before repopulating
            lstBoxCountries.ItemsSource = null;
            grdCities.ItemsSource = null;
            lblLanguages.Content = "";
            lblCurrencies.Content = "";
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

        private void cmbBoxContinents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearFields();

            if (cmbBoxContinents.SelectedItem != null) // Check if an item is selected
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
                {

                    string query = "SELECT CountryName FROM Country cntry INNER JOIN Continent cont ON cntry.ContinentId = cont.ContinentId WHERE cont.ContinentName = @ContinentName";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("ContinentName", cmbBoxContinents.SelectedItem.ToString());

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> countryNames = new List<string>();
                    while (reader.Read())
                    {
                        string countrytName = reader["CountryName"].ToString();
                        countryNames.Add(countrytName);
                    }

                    lstBoxCountries.ItemsSource = countryNames;
                }
            }
        }

        private void lstBoxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstBoxCountries.SelectedItem != null) // Check if an item is selected
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
                {
                    string query = "SELECT CityName, IsCapital, Population FROM City c INNER JOIN Country cntry ON c.CountryId = cntry.CountryId WHERE cntry.CountryName = @CountryName";

                    SqlCommand cmdCities = new SqlCommand(query, conn);
                    cmdCities.Parameters.AddWithValue("CountryName", lstBoxCountries.SelectedItem.ToString());

                    conn.Open();

                    SqlDataReader readerCities = cmdCities.ExecuteReader();

                    DataTable tblCities = new DataTable();
                    tblCities.Load(readerCities);

                    grdCities.ItemsSource = tblCities.DefaultView;

                    readerCities.Close();


                    //Populate country language list
                    List<string> countryLanguages = new List<string>();
                    List<string> countryCurrencies = new List<string>();
                    string queryLanguages = "SELECT Language, Currency FROM Country WHERE CountryName = @CountryName";

                    SqlCommand cmdLanguages = new SqlCommand(queryLanguages, conn);
                    cmdLanguages.Parameters.AddWithValue("@CountryName", lstBoxCountries.SelectedItem.ToString());

                    SqlDataReader readerLanguages = cmdLanguages.ExecuteReader();

                    while (readerLanguages.Read())
                    {
                        string countryLanguage = readerLanguages["Language"].ToString();
                        countryLanguages.Add(countryLanguage);

                        string countryCurrency = readerLanguages["Currency"].ToString();
                        countryCurrencies.Add(countryCurrency);

                    }

                    // Close the language reader after reading the data
                    readerLanguages.Close();

                    //Read from language list and populate label
                    lblLanguages.Content = string.Join(", ", countryLanguages);

                    //Read from currency list and populate label
                    lblCurrencies.Content = string.Join(", ", countryCurrencies);
                }
            }
        }

        private void btnAddContinent_Click(object sender, RoutedEventArgs e)
        {
            AddContinent addContinentWindow = new AddContinent(this);
            addContinentWindow.ShowDialog();
        }

        private void btnAddCountry_Click(object sender, RoutedEventArgs e)
        {
            AddCountry addCountryWindow = new AddCountry(this);
            addCountryWindow.ShowDialog();

        }

        private void btnAddCity_Click(object sender, RoutedEventArgs e)
        {
            AddCity addCityWindow = new AddCity(this);
            addCityWindow.ShowDialog();
        }
    }
}
