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
using BusinessObjects; // Assuming BusinessObjects namespace contains the Employees class
using Services; // Assuming Services namespace contains the EmployeeService class

namespace ĐàoNguyênKhôiWPF
{
    /// <summary>
    /// Interaction logic for AdminDashBoardWindow.xaml
    /// </summary>
    public partial class AdminDashBoardWindow : Window
    {
        private Employees iloggedInEmployee;
        readonly ICustomerService icustomerService;
        bool isCompleted = false;
        public AdminDashBoardWindow(Employees loggedInEmployee)
        {
            InitializeComponent();
            icustomerService = new CustomerService();
            iloggedInEmployee = new Employees();

            this.Title = $"Welcome, {iloggedInEmployee.Name}";
        }

        private void btnCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagementWindow cmw = new CustomerManagementWindow();
            cmw.Show();
        }

        private void btnProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ProductManagementWindow pmw = new ProductManagementWindow();
            pmw.Show();
        }
    }
}
