using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

namespace BookShop {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class OrderSummary : Window {
        SqlConnection sqlConnection;
        public OrderSummary() {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["BookShop.Properties.Settings.PeemBookShopDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowOrderSummary();
            TotalPrice();
            TotalSell();
        }
        private void ShowOrderSummary() {
            try {
                string query = "select * from Orders where CustomerIdOrder = @CustomerIdOrder";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter) {
                    sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", LastCustomerId());
                    DataTable customerDataTable = new DataTable();
                    sqlDataAdapter.Fill(customerDataTable);
                    listBook.ItemsSource = customerDataTable.DefaultView;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void TotalPrice() {
            string query = "select sum (OrderPrice) from Orders where CustomerIdOrder = @CustomerIdOrder";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", LastCustomerId());
            sqlConnection.Open();
            object total = sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            totalPrice.Text = total.ToString();
        }

        private void TotalSell() {
            try {
                string query = "select sum (Total) from TotalSell";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                object total = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                totalSell.Text = total.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        private string LastCustomerId() {
            string query1 = "select top 1 Id from TotalSell order by 1 desc";
            SqlCommand command = new SqlCommand(query1, sqlConnection);
            sqlConnection.Open();
            object Id = command.ExecuteScalar();
            sqlConnection.Close();
            //MessageBox.Show(Id.ToString());
            string query2 = "select CustomerId from TotalSell where Id = @Id";
            SqlCommand command1 = new SqlCommand(query2, sqlConnection);
            command1.Parameters.AddWithValue("@Id", Id.ToString());
            sqlConnection.Open();
            object customerId = command1.ExecuteScalar();
            sqlConnection.Close();
            //MessageBox.Show(customerId.ToString());
            return customerId.ToString();
        }
    }

}
