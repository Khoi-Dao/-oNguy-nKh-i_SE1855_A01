using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects; // Assuming BusinessObjects namespace contains the Customer class
using Repositories; // Assuming Repositories namespace contains the ICustomerRepository interface

namespace Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomersRepository icustomerRepository;
        public CustomerService()
        {
            icustomerRepository = new CustomersRepository();
        }
        //public void GenerateSampleData()
        //{
        //    icustomerRepository.GenerateSampleData();
        //}
        public List<Customers> GetAllCustomers()
        {
            return icustomerRepository.GetAllCustomers();
        }
    }
}
