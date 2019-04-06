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
    /// Interaction logic for ManageBooks.xaml
    /// </summary>
    public partial class ManageBooks : Window {
        SqlConnection sqlConnection;
        public ManageBooks() {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["BookShop.Properties.Settings.PeemBookShopDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
        }
        private void ShowBooks() {
            string query = "select * from Books";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            using (sqlDataAdapter) {
                DataTable customerDataTable = new DataTable();
                sqlDataAdapter.Fill(customerDataTable);
                listBook.SelectedValuePath = "ISBN";
                listBook.ItemsSource = customerDataTable.DefaultView;
            }
        }
        private void ClickSystem(string query) {
            try {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ISBN", ISBNTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Title", TitleTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Description", DescriptionTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Price", PriceTxt.Text);
                sqlCommand.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally {
                sqlConnection.Close();
                ShowBooks();
            }
        }
        private void SearchBook(string query, string field, TextBox textBox) {
            try {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter) {
                    sqlCommand.Parameters.AddWithValue(field, textBox.Text);
                    DataTable customerTable = new DataTable();
                    sqlDataAdapter.Fill(customerTable);
                    listBook.ItemsSource = customerTable.DefaultView;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        private void AddBook_Click(object sender, RoutedEventArgs e) {
            ClickSystem("insert into Books values (@ISBN, @Title, @Description, @Price)");
        }

        private void SearchBook_Click(object sender, RoutedEventArgs e) {
            if (ISBNTxt.Text != "") {
                SearchBook("select * from Books where ISBN = @ISBN", "@ISBN", ISBNTxt);
            } else if (TitleTxt.Text != "") {
                SearchBook("select * from Books where Title = @Title", "@Title", TitleTxt);
            } else if (DescriptionTxt.Text != "") {
                SearchBook("select * from Books where Description = @Description", "@Description", DescriptionTxt);
            } else if (PriceTxt.Text != "") {
                SearchBook("select * from Books where Price = @Price", "@Price", PriceTxt);
            }
        }

        private void UpdateBook_Click(object sender, RoutedEventArgs e) {
            ClickSystem("update Books set Title = @Title where ISBN = @ISBN; " +
                    "update Books set Description = @Description where ISBN = @ISBN;" +
                    "update Books set Price = @Price where ISBN = @ISBN");
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e) {
            ClickSystem("delete from Books where ISBN = @ISBN; delete from Books where Title = @Title;" +
               "delete from Books where Description = @Description; delete from Books where Price = @Price");
        }

        private void ShowDataBook_Click(object sender, RoutedEventArgs e) {
            ShowBooks();
        }

        private void ListBook_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                string query = "select * from Books where ISBN = @ISBN";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@ISBN", listBook.SelectedValue);
                DataTable CustomerTable = new DataTable();
                sqlDataAdapter.Fill(CustomerTable);
                foreach (DataRow dr in CustomerTable.Rows) {
                    ISBNTxt.Text = dr["ISBN"].ToString();
                    TitleTxt.Text = dr["Title"].ToString();
                    DescriptionTxt.Text = dr["Description"].ToString();
                    PriceTxt.Text = dr["Price"].ToString();
                }
            } catch (Exception) {
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
