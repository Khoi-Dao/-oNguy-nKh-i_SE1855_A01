using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Employees
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string JobTitle { get; set; } = null!;

        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }

        public string? Address { get; set; } = null!;

        public Employees() { }

        public Employees(int employeeId, string name, string userName, string password, string jobTitle, DateTime birthDate, DateTime hireDate, string address)
        {
            this.EmployeeID = employeeId;
            this.Name = name;
            this.UserName = userName;
            this.Password = password;
            this.JobTitle = jobTitle;
            this.BirthDate = birthDate;
            this.HireDate = hireDate;
            this.Address = address;
        }

        override public string ToString()
        {
            return $"{EmployeeID} - {Name} - {UserName} - {JobTitle} - {BirthDate.ToShortDateString()} - {HireDate.ToShortDateString()} - {Address}";
        }
    }
}
