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
    /// Interaction logic for OrderBooks.xaml
    /// </summary>
        public partial class OrderBooks : Window {
        SqlConnection sqlConnection;
        
        public OrderBooks() {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["BookShop.Properties.Settings.PeemBookShopDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            ShowBooks();
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
        private void ShowBooksCart() {
            string query = "select * from Orders where CustomerIdOrder = @CustomerIdOrder";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            using (sqlDataAdapter) {
                sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", CustomerIdTxt.Text);
                DataTable customerDataTable = new DataTable();
                sqlDataAdapter.Fill(customerDataTable);
                listOrder.SelectedValuePath = "OrderISBN";
                listOrder.ItemsSource = customerDataTable.DefaultView;
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
        private void SearchBook_Click(object sender, RoutedEventArgs e) {
            if (ISBNTxt.Text != "") {
                SearchBook("select * from Books where ISBN = @ISBN", "@ISBN", ISBNTxt);
            } else if (TitleTxt.Text != "") {
                SearchBook("select * from Books where Title = @Title", "@Title", TitleTxt);
            } 
        }
        private void AddBookToCart_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "insert into Orders values (@CustomerIdOrder, @Quantity, @OrderISBN, @OrderPrice, @OrderTitle)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", CustomerIdTxt.Text);
                sqlCommand.Parameters.AddWithValue("@OrderISBN", ISBNShowTxt.Text);
                sqlCommand.Parameters.AddWithValue("@OrderTitle", TitleShowTxt.Text);
                sqlCommand.Parameters.AddWithValue("@OrderPrice", TotalPriceTxt.Text);
                sqlCommand.Parameters.AddWithValue("@Quantity", QuantityTxt.Text);
                sqlCommand.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally {
                sqlConnection.Close();
                ShowBooksCart();
                TotalPrice();
            }
        }
        private void DeleteBookFromCart_Click(object sender, RoutedEventArgs e) {
            try {
                string query = "delete from Orders where CustomerIdOrder = @CustomerIdOrder and OrderISBN = @OrderISBN";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", CustomerIdTxt.Text);
                sqlCommand.Parameters.AddWithValue("@OrderISBN", listOrder.SelectedValue);
                sqlCommand.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally {
                sqlConnection.Close();
                ShowBooksCart();
                TotalPrice();
            }
        }
        private void Checkout_Click(object sender, RoutedEventArgs e) {
            try {
                MessageBox.Show("Successfully, Thank you for your order !");
                string query = "insert into TotalSell values (@Total, @CustomerId)";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Total", totalPrice.Text);
                sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerIdTxt.Text);
                sqlCommand.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            } finally {
                sqlConnection.Close();
                OrderSummary orderSummary = new OrderSummary();
                orderSummary.ShowDialog();
            }
        }

        private void ListBook_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                string query = "select * from Books where ISBN = @ISBN";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@ISBN", listBook.SelectedValue);
                DataTable bookDataTable = new DataTable();
                sqlDataAdapter.Fill(bookDataTable);
                foreach (DataRow dr in bookDataTable.Rows) {
                    ISBNShowTxt.Text = dr["ISBN"].ToString();
                    TitleShowTxt.Text = dr["Title"].ToString();
                    PriceShowTxt.Text = dr["Price"].ToString();
                }
            } catch (Exception) {
            }
        }

        private void ShowMyCart_Click(object sender, RoutedEventArgs e) {
            ShowBooksCart();
            TotalPrice();
        }

        private void ListOrder_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                string query = "select * from Orders where CustomerIdOrder = @CustomerIdOrder";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", listOrder.SelectedValue);
                DataTable orderDataTable = new DataTable();
                sqlDataAdapter.Fill(orderDataTable);
                foreach (DataRow dr in orderDataTable.Rows) {
                    ISBNShowTxt.Text = dr["OrderISBN"].ToString();
                    TitleShowTxt.Text = dr["OrderTitle"].ToString();
                    PriceShowTxt.Text = dr["OrderPrice"].ToString();
                    CustomerIdTxt.Text = dr["CustomerIdOrder"].ToString();
                    QuantityTxt.Text = dr["Quantity"].ToString();
                }
            } catch (Exception) {
            }
        }
        private void TotalPrice() {
            try {
                string query = "select sum (OrderPrice) from Orders where CustomerIdOrder = @CustomerIdOrder";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CustomerIdOrder", CustomerIdTxt.Text);
                sqlConnection.Open();
                object total = sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                totalPrice.Text = total.ToString();
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void QuantityTxt_TextChanged(object sender, TextChangedEventArgs e) {
            try {
                double bookPrice, quantity, total;
                bookPrice = double.Parse(PriceShowTxt.Text);
                quantity = double.Parse(QuantityTxt.Text);
                total = bookPrice * quantity;
                TotalPriceTxt.Text = $"{total}";
            } catch (Exception) {
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
