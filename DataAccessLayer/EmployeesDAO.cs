using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer
{
    public class EmployeesDAO
    {
        private string connectionString = "Data Source=VU-LAPTOP\\SQLEXPRESS;Initial Catalog=Lucy_SalesData;user id=sa; Password=12345;Encrypt=false;TrustServerCertificate=true";
        public List<Employees> employees = new List<Employees>();
        public List<Employees> GetAllEmployees()
        {
            var result = new List<Employees>();
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM Employees";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var employee = new Employees
                {
                    EmployeeID = reader.GetInt32(reader.GetOrdinal("EmployeeID")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                    Password = reader.GetString(reader.GetOrdinal("Password")),
                    JobTitle = reader.GetString(reader.GetOrdinal("JobTitle")),
                    BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                    HireDate = reader.GetDateTime(reader.GetOrdinal("HireDate")),
                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"))
                };
                result.Add(employee);
            }
            return result;
        }
        public Employees? LoginController(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                string query = "SELECT EmployeeID, Name, UserName, Password, JobTitle " +
                    "FROM Employees WHERE UserName = @UserName AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Employees employee = new Employees
                        {
                            EmployeeID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            UserName = reader.GetString(2),
                            Password = reader.GetString(3),
                            JobTitle = reader.GetString(4)
                        };
                        return employee;
                    }
                    else
                    {
                        return null; 
                    }
                }
                catch (Exception ex) 
                {
                    throw new Exception("Error logging in: " + ex.Message);
                }
            }
        }
    }
}
