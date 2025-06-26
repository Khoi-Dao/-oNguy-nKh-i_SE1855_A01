using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects; // Assuming BusinessObjects namespace contains the Customer class
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;


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
        public Customers? GetCustomerById(int customerId) //chưa implement
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CustomerID", customerId);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Customers
                {
                    CustomerID = reader.GetInt32(reader.GetOrdinal("CustomerID")),
                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                    ContactName = reader.GetString(reader.GetOrdinal("ContactName")),
                    ContactTitle = reader.GetString(reader.GetOrdinal("ContactTitle")),
                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                    Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone"))
                };
            }
            return null;
        }
        public bool AddCustomer(Customers customer)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();

            // Check if a customer with the same company and phone already exists
            string checkSql = @"
        SELECT COUNT(*) FROM Customers 
        WHERE CompanyName = @CompanyName AND Phone = @Phone";

            using var checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
            checkCmd.Parameters.AddWithValue("@Phone", (object)customer.Phone ?? DBNull.Value);
            int count = (int)checkCmd.ExecuteScalar();

            if (count > 0)
            {
                return false; // Customer already exists
            }

            // Insert
            string sql = @"
        INSERT INTO Customers (CompanyName, ContactName, ContactTitle, Address, Phone)
        VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @Phone)";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
            cmd.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
            cmd.Parameters.AddWithValue("@Address", (object)customer.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", (object)customer.Phone ?? DBNull.Value);

            int rowsAffected = cmd.ExecuteNonQuery();
            return rowsAffected > 0;
        }
        public bool UpdateCustomer(Customers customer)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string checkSql = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @CustomerID";
            using var checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                return false; // Customer does not exist
            }
            string sql = @"
        UPDATE Customers 
        SET CompanyName = @CompanyName,
            ContactName = @ContactName,
            ContactTitle = @ContactTitle,
            Address = @Address,
            Phone = @Phone
        WHERE CustomerID = @CustomerID";

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
            cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", customer.ContactName);
            cmd.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
            cmd.Parameters.AddWithValue("@Address", (object)customer.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", (object)customer.Phone ?? DBNull.Value);

            cmd.ExecuteNonQuery();
            return true; // Customer updated successfully
        }
        public bool DeleteCustomer(int customerId)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string checkSql = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @CustomerID";
            using var checkCmd = new SqlCommand(checkSql, conn);
            checkCmd.Parameters.AddWithValue("@CustomerID", customerId);
            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                return false; // Customer does not exist
            }
            string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@CustomerID", customerId);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
