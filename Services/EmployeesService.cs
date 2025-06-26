using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories; // Assuming Repositories namespace contains the IEmployeesRepository interface

namespace Services
{
    public class EmployeesService : IEmployeesService
    {private readonly IEmployeesRepository iemployeesRepository;
        public EmployeesService()
        {
            iemployeesRepository = new EmployeesRepository();
        }
        public List<Employees> GetAllEmployees()
        {
            return iemployeesRepository.GetAllEmployees();
        }

        public Employees? LoginController(string userName, string password)
        {
            return iemployeesRepository.LoginController(userName, password);
        }
    }
}
