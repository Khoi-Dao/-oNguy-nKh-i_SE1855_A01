using BusinessObjects;
using Services;
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
    /// Interaction logic for CustomerManagementWindow.xaml
    /// </summary>
    public partial class CustomerManagementWindow : Window
    {
        private Employees iloggedInEmployee;
        readonly ICustomerService icustomerService;
        bool isCompleted = false;
        public CustomerManagementWindow()
        {
            InitializeComponent();
            icustomerService = new CustomerService();
            LoadCustomers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void LoadCustomers()
        {
            isCompleted = false;
            lvCustomers.ItemsSource = icustomerService.GetAllCustomers();
            isCompleted = true;
        }

        private void lvCustomert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false) return;
            if (e.AddedItems.Count < 0)
            {
                return; // người dùng chua lựa chon dòng nào
            }
            Customers c = (Customers)e.AddedItems[0] as Customers;
            if (c == null) return;
            txtCustomerId.Text = c.CustomerID.ToString();
            txtCompanyName.Text = c.CompanyName;
            txtContactName.Text = c.ContactName;
            txtContactTitle.Text = c.ContactTitle;
            txtAddress.Text = c.Address ?? string.Empty;
            txtPhone.Text = c.Phone ?? string.Empty;

        }

        private void btnThemKhachHang_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int id = int.Parse(txtCustomerId.Text);
                string companyName = txtCompanyName.Text.Trim();
                string contactName = txtContactName.Text.Trim();
                string contactTitle = txtContactTitle.Text.Trim();
                string address = txtAddress.Text.Trim();
                string phone = txtPhone.Text.Trim();
                Customers c = new Customers()
                {
                    CustomerID = id,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    Phone = phone
                };

                bool result = icustomerService.AddCustomer(c);
                if (result)
                {
                    lvCustomers.ItemsSource = null; // Clear the current items source
                    lvCustomers.ItemsSource = icustomerService.GetAllCustomers(); // Reload the customers
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi thêm khách hàng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int id = int.Parse(txtCustomerId.Text);
                string companyName = txtCompanyName.Text.Trim();
                string contactName = txtContactName.Text.Trim();
                string contactTitle = txtContactTitle.Text.Trim();
                string address = txtAddress.Text.Trim();
                string phone = txtPhone.Text.Trim();
                Customers c = new Customers()
                {
                    CustomerID = id,
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    Phone = phone
                };

                bool result = icustomerService.UpdateCustomer(c);
                if (result)
                {
                    lvCustomers.ItemsSource = null; // Clear the current items source
                    lvCustomers.ItemsSource = icustomerService.GetAllCustomers(); // Reload the customers
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi thêm khách hàng", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ret = MessageBox.Show(
                "Are you really sure you want to delete this?",
                //nội dung câu hỏi cửa sổ
                "Delete Confirmation",
                //tiêu đề cửa số
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (ret == MessageBoxResult.No)
            {
                return; // người dùng không muốn xóa
            }
            isCompleted = false;
            Customers cDel = new Customers();
            cDel.CustomerID = int.Parse(txtCustomerId.Text);
            bool result = icustomerService.DeleteCustomer(cDel.CustomerID);
            if (result == true)
            {
                lvCustomers.ItemsSource = null; // Clear the current items source
                lvCustomers.ItemsSource = icustomerService.GetAllCustomers(); // Reload the customers
            }
            isCompleted = true;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                string SearchByCustomerId = txtSearchByCustomerId.Text.Trim();
                if (string.IsNullOrEmpty(SearchByCustomerId))
                {
                    LoadCustomers();
                    return;
                }
                if (int.TryParse(txtSearchByCustomerId.Text.Trim(), out int id))
                {
                    var found = icustomerService.GetCustomerById(id);
                    lvCustomers.ItemsSource = null;
                    if (found != null)
                    {
                        lvCustomers.ItemsSource = new List<Customers> { found };
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng với ID đã nhập.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        lvCustomers.ItemsSource = new List<Customers>(); // Optional: clear list
                    }
                }
                isCompleted = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi tìm kiếm khách hàng", MessageBoxButton.OK, MessageBoxImage.Error);
            }    
        }
    }
}
