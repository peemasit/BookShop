using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookShop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        SqlConnection sqlConnection;

        public MainWindow() {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["BookShop.Properties.Settings.PeemBookShopDBConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            //OrderBooks orderBooks = new OrderBooks();
            //orderBooks.ShowDialog();
            //OrderSummary orderSummary = new OrderSummary();
            //orderSummary.ShowDialog();
        }

        private void Login_Click(object sender, RoutedEventArgs e) {
            if (UserTxt.Text == "admin" && PasswordTxt.Password.ToString() == "123456") {
                MessageBox.Show("login successful");
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowDialog();
            } else {
                MessageBox.Show("incorrent username or password");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        
    }
}
