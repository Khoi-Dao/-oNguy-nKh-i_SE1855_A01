using BusinessObjects; // Assuming BusinessObjects namespace contains the Customers class
using Services; // Assuming Services namespace contains the CustomerService class
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ĐàoNguyênKhôiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Employees iloggedInEmployee;
        readonly ICustomerService icustomerService;
          bool isCompleted = false;
        public MainWindow(Employees loggedInEmployee)
        {
            InitializeComponent();
            icustomerService = new CustomerService();
            iloggedInEmployee = new Employees();

            this.Title = $"Welcome, {iloggedInEmployee.Name}";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            LoadCustomers();


        }
        private void LoadCustomers()
        {
            isCompleted = false;
            lvCustomers.ItemsSource = icustomerService.GetAllCustomers();
            isCompleted = true;
        }
       
    }
    
}