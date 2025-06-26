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
        //public void GenerateSampleData()
        //{
        //    customerDAO.GenerateSampleData();
        //}

        public List<Customers> GetAllCustomers()
        {
            return customerDAO.GetAllCustomers();
        }
    }
}
