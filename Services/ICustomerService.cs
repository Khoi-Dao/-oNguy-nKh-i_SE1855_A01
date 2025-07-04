﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects; // Assuming BusinessObjects namespace contains the Customer class
using Repositories; // Assuming Repositories namespace contains the ICustomersRepository interface

namespace Services
{
    public interface ICustomerService
    {
        //public void GenerateSampleData();
        public List<Customers> GetAllCustomers();
        public Customers? GetCustomerById(int customerId);
        public bool AddCustomer(Customers customer);
        public bool UpdateCustomer(Customers customer);
        public bool DeleteCustomer(int customerId);
    }
}
