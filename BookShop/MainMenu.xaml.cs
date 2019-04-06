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

namespace BookShop {
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window {
        public MainMenu() {
            InitializeComponent();
        }

        private void ManageCustomers_Click(object sender, RoutedEventArgs e) {
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.ShowDialog();
        }

        private void ManageBooks_Click(object sender, RoutedEventArgs e) {
            ManageBooks manageBooks = new ManageBooks();
            manageBooks.ShowDialog();
        }

        private void OrderBooks_Click(object sender, RoutedEventArgs e) {
            OrderBooks orderBooks = new OrderBooks();
            orderBooks.ShowDialog();
        }
    }
}
