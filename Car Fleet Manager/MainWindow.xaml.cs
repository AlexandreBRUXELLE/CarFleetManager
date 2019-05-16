using System;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Car_Fleet_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            // connection string to database
            string connectionStringDB = ConfigurationManager.ConnectionStrings["Car_Fleet_Manager.Properties.Settings.SunlistDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionStringDB);

            ShowAllCarFleets();
            ShowAllCars();

        }

        //show all Car Fleets in a listBox #1 (name: listCarFleet)
        private void ShowAllCarFleets()
        {
            try
            {
                string query = "select * from CarFleet";

                // Display sqlDataAdapter as an interface that makes tables use C # objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable carFleetTable = new DataTable();

                    sqlDataAdapter.Fill(carFleetTable);
                    // show placement information in the listCarFleet
                    listCarFleet.DisplayMemberPath = "Location";
                    // select the value from the table in the listCarFleet
                    listCarFleet.SelectedValuePath = "Id";
                    // references to data must be filled out
                    listCarFleet.ItemsSource = carFleetTable.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ShowAvailableCars()
        {
            try
            {
                string query = "select * from Car c inner join CarRegister cr " +
                    "on c.Id = cr.CarId where cr.CarFleetId = @CarFleetId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // Display sqlDataAdapter as an interface that makes tables use C# objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@CarFleetId", listCarFleet.SelectedValue);

                    DataTable availableCarTable = new DataTable();

                    sqlDataAdapter.Fill(availableCarTable);
                    // show placement information in the listAvailableCars
                    listAvailableCars.DisplayMemberPath = "Brand";
                    // select the value from the table in the listAvailableCars
                    listAvailableCars.SelectedValuePath = "Id";
                    // references to data must be filled out
                    listAvailableCars.ItemsSource = availableCarTable.DefaultView;

                }
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }

        private void ShowAllCars()
        {
            try
            {
                string query = "select * from Car";

                // Display sqlDataAdapter as an interface that makes tables use C # objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                using (sqlDataAdapter)
                {

                    DataTable allCarTable = new DataTable();

                    sqlDataAdapter.Fill(allCarTable);
                    // show placement information in the listAllCars
                    listAllCars.DisplayMemberPath = "Brand";
                    // select the value from the table in the listAllCars
                    listAllCars.SelectedValuePath = "Id";
                    // references to data must be filled out
                    listAllCars.ItemsSource = allCarTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // // show selected car from list #1 in TextBox
        private void ListCarFleet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAvailableCars();
            ShowSelectedCarFleetInTextBox();
        }

        private void DeleteCarFleet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from CarFleet where id = @CarFleetId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CarFleetId", listCarFleet.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllCarFleets();
            }

        }

        private void AddCarFleet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into CarFleet values (@Location)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", carTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllCarFleets();
            }
        }


        private void AddCarToCarFleet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into CarRegister values (@CarFleetId, @CarId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CarFleetId", listCarFleet.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@CarId", listAllCars.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAvailableCars();
            }
        }

        private void RemoveCarFromRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "delete from Car where id = @CarId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CarId", listAllCars.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllCars();
            }
        }


        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Car values (@Brand)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Brand", carTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllCars();
            }
        }

        private void ShowSelectedCarFleetInTextBox()
        {
            try
            {
                string query = "select location from CarFleet where id = @CarFleetId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // Display sqlDataAdapter as an interface that makes tables use C # objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@CarFleetId", listCarFleet.SelectedValue);

                    DataTable carFleetDataTable = new DataTable();
                    sqlDataAdapter.Fill(carFleetDataTable);

                    carTextBox.Text = carFleetDataTable.Rows[0]["Location"].ToString();
                }

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }


        private void ShowSelectedRegisterCarsInTextBox()
        {
            try
            {
                string query = "select brand from Car where id = @CarId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // Display sqlDataAdapter as an interface that makes tables use C # objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@CarId", listAllCars.SelectedValue);

                    DataTable allCarsTable = new DataTable();
                    sqlDataAdapter.Fill(allCarsTable);

                    carTextBox.Text = allCarsTable.Rows[0]["Brand"].ToString();
                }

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }

        // show selected car from list #3 in TextBox
        private void ListAllCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedRegisterCarsInTextBox();
        }

        private void UpdateCarFleets_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update CarFleet set Location = @Location where id = @CarFleetId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CarFleetId", listCarFleet.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Location", carTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllCarFleets();
            }
        }


        private void ShowSelectedAvailableCarInTextBox()
        {
            try
            {
                string query = "select brand from Car where id = @CarId";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                // Display sqlDataAdapter as an interface that makes tables use C # objects
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    sqlCommand.Parameters.AddWithValue("@CarId", listAvailableCars.SelectedValue);

                    DataTable availableCarsTable = new DataTable();
                    sqlDataAdapter.Fill(availableCarsTable);

                    carTextBox.Text = availableCarsTable.Rows[0]["Brand"].ToString();
                }

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }

        // method for update brand of selected car
        // also this method can update all cars on list #3
        private void UpdateCarRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "update Car set Brand = @Brand where id = @CarId";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CarId", listAllCars.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Brand", carTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllCars();
            }
        }

        // show the second wpf window with description 
        private void MenuDescription_Click(object sender, RoutedEventArgs e)
        {
            HelpDescriptionWindow descriptionWindow = new HelpDescriptionWindow();
            descriptionWindow.Show();
        }

        // show selected car from list #2 in TextBox
        private void ListAvailableCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAvailableCarInTextBox();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }
    }
}
