using BusinessObjects; // Assuming this namespace contains the Employees class
using DataAccessLayer;
using Services; // Assuming this namespace contains the EmployeesService class
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

namespace ĐàoNguyênKhôiWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private EmployeesDAO iemployeesDAO = new EmployeesDAO();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = UserName.Text;
            string password = PasswordBox.Password;

            Employees? employee = iemployeesDAO.LoginController(username, password);
            if (employee != null)
            {
                // Login successful, proceed to the main application window
                AdminDashBoardWindow adbw = new AdminDashBoardWindow(employee);
                adbw.Show();
                this.Close(); // Close the login window
            }
            else
            {
                // Show error message for failed login
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
