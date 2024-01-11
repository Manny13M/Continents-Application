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
    /// Interaction logic for AddContinent.xaml
    /// </summary>
    public partial class AddContinent : Window
    {
        private MainWindow mainWindow;

        public AddContinent(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void btnAddContinentToDB_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContinentName.Text.ToString())) // Check if an item is selected
            {
                using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
                {
                    string query = "INSERT INTO Continent (Continentname) VALUES (@ContinentName)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("ContinentName", txtContinentName.Text.ToString());

                    conn.Open();

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1) 
                    {
                        MessageBox.Show("Continent inserted");
                        txtContinentName.Text = "";
                    }
                    else
                        MessageBox.Show("Continent not inserted");
                }
            }
            else
            {
                MessageBox.Show("No continent name was entered.");
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
