using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Customers
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactName { get; set; } = null!;
        public string ContactTitle { get; set; } = null!;
        public string? Address { get; set; } = null!;
        public string? Phone { get; set; } = null!;

        public Customers() { }
        public Customers(int customerId, string companyName, string contactName, string contactTitle, string address, string phone)
        {
            this.CustomerID = customerId;
            this.CompanyName = companyName;
            this.ContactName = contactName;
            this.ContactTitle = contactTitle;
            this.Address = address;
            this.Phone = phone;
        }
        override public string ToString()
        {
            return $"{CustomerID} - {CompanyName} - {ContactName} - {ContactTitle} - {Address} - {Phone}";
        }
    }
}
