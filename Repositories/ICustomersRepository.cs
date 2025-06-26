using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   public interface ICustomersRepository
    {
        //public void GenerateSampleData();
        public List<Customers> GetAllCustomers();
        public Customers? GetCustomerById(int customerId);
        public bool AddCustomer(Customers customer);
        public bool UpdateCustomer(Customers customer);
        public bool DeleteCustomer(int customerId);
    }
}
