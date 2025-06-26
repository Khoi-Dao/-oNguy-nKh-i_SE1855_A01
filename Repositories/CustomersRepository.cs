using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        CustomerDAO customerDAO = new CustomerDAO();

        public bool AddCustomer(Customers customer)
        {
            return customerDAO.AddCustomer(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return customerDAO.DeleteCustomer(customerId);
        }

        //public void GenerateSampleData()
        //{
        //    customerDAO.GenerateSampleData();
        //}

        public List<Customers> GetAllCustomers()
        {
            return customerDAO.GetAllCustomers();
        }

        public Customers? GetCustomerById(int customerId)
        {
            return customerDAO.GetCustomerById(customerId);
        }

        public bool UpdateCustomer(Customers customer)
        {
            return customerDAO.UpdateCustomer(customer);
        }
    }
}
