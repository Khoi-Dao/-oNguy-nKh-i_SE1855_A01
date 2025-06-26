using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        EmployeesDAO employeesDAO = new EmployeesDAO();
        public List<Employees> GetAllEmployees()
        {
            return employeesDAO.GetAllEmployees();
        }

        public Employees? LoginController(string userName, string password)
        {
            return employeesDAO.LoginController(userName, password);
        }
    }
}
