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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BookShop {
    
    /// <summary>
    /// Interaction logic for ManageCustomers.xaml
    /// </summary>
    public partial class ManageCustomers : Window  {

        SqlConnection sqlConnection;

        public ManageCustomers() {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["BookShop.Properties.Settings.PeemBookShopDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }
        private void ShowCustomer() {
            string query = "select * from Customers";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            using (sqlDataAdapter) {
                DataTable customerDataTable = new DataTable();
                sqlDataAdapter.Fill(customerDataTable);
                listCustomer.SelectedValuePath = "Id";
                listCustomer.ItemsSource = customerDataTable.DefaultView;
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e) {
            ClickSystem("insert into Customers values (@Id, @Name, @Address, @Email)");
        }
        private void SearchCustomer_Click(object sender, RoutedEventArgs e) {
            if (IdTxt.Text != "") { 
                SearchCustomer("select * from Customers where Id = @Id", "@Id", IdTxt);
            } else if (NameTxt.Text != "") {
                SearchCustomer("select * from Customers where Name = @Name", "@Name", NameTxt);
            } else if (AddressTxt.Text != "") {
                SearchCustomer("select * from Customers where Address = @Address", "@Address", AddressTxt);
            } else if (EmailTxt.Text != "") {
                SearchCustomer("select * from Customers where Email = @Email", "@Email", EmailTxt);
            }
        }
        private void UpdateCustomer_Click(object sender, RoutedEventArgs e) {
            ClickSystem("update customers set Name = @Name where Id = @Id; " +
                    "update customers set Address = @Address where Id = @Id;" +
                    "update customers set Email = @Email where Id = @Id");
        }
        private void DeleteCustomer_Click(object sender, RoutedEventArgs e) {
            ClickSystem("delete from Customers where Id = @Id; delete from Customers where Name = @Name;" +
               "delete from Customers where Address = @Address; delete from Customers where Email = @Email");
        }
        private void ShowDataCustomer_Click(object sender, RoutedEventArgs e) {
            ShowCustomer();
        }


        private void ListCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                string query = "select * from Customers where Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@Id", listCustomer.SelectedValue);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows) {
                    IdTxt.Text = dr["Id"].ToString();
                    NameTxt.Text = dr["Name"].ToString();
                    AddressTxt.Text = dr["Address"].ToString();
                    EmailTxt.Text = dr["Email"].ToString();
                }
            } catch (Exception) {
            }
        }

        private void SearchCustomer(string query, string field, TextBox textBox) {
            try {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter) {
                    sqlCommand.Parameters.AddWithValue(field, textBox.Text);
                    DataTable customerTable = new DataTable();
                    sqlDataAdapter.Fill(customerTable);
                    listCustomer.ItemsSource = customerTable.DefaultView;
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ClickSystem(string query) {
            try {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Id", IdTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Name", NameTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Address", AddressTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Email", EmailTxt.Text);
                sqlCommand.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally {
                sqlConnection.Close();
                ShowCustomer();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }

    


}
