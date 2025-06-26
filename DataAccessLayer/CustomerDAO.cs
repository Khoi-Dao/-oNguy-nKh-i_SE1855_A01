using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects; // Assuming BusinessObjects namespace contains the Customer class
using Microsoft.Data.SqlClient;


namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private string connectionString = "Data Source=VU-LAPTOP\\SQLEXPRESS;Initial Catalog=Lucy_SalesData;user id=sa; Password=12345;Encrypt=false;TrustServerCertificate=true";
        public List<Customers> customers = new List<Customers>();
        //public void GenerateSampleData()
        //{
        //    customers.Add(new Customers(1, "Company A", "Alice Smith", "Manager", "123 Main St", "555-1234"));
        //    customers.Add(new Customers(2, "Company B", "Bob Johnson", "Director", "456 Elm St", "555-5678"));
        //    customers.Add(new Customers(3, "Company C", "Charlie Brown", "CEO", "789 Oak St", "555-8765"));
        //    customers.Add(new Customers(4, "Company D", "Diana Prince", "CTO", "321 Pine St", "555-4321"));
        //    customers.Add(new Customers(5, "Company E", "Ethan Hunt", "Agent", "654 Maple St", "555-6789"));
        //}
        public List<Customers> GetAllCustomers()
        {
            var customers = new List<Customers>();
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM Customers";
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var customer = new Customers
                {
                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                    ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                    ContactTitle = reader.GetString(reader.GetOrdinal("ContactTitle")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                };
                customers.Add(customer);
            }





            // Simulate fetching data from a database
            return customers;
        }
    }
}
