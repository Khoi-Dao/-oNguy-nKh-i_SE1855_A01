using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEmployeesRepository
    {
        public List<Employees> GetAllEmployees();
        public Employees? LoginController(string userName, string password);

    }
}
