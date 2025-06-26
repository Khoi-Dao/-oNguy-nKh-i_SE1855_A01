using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmployeesService
    {
        public List<Employees> GetAllEmployees();
        public Employees? LoginController(string userName, string password);
    }
}
