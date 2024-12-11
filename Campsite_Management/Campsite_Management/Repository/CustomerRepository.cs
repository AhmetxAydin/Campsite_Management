using Campsite_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Campsite_Management.Repository
{
    public class CustomerRepository
    {
        public string connectionString;
        public CustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CustomerModel> GetCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            string query = "SELECT * FROM Customers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CustomerModel customer = new CustomerModel
                    {
                        Id = (int)reader["ID"],
                        CampId = (int)reader["Camp_ID"],
                        plaka = (string)reader["Plaka"],
                        firstName = (string)reader["First_Name"],
                        lastName = (string)reader["Last_Name"],
                        customerPhone = (string)reader["Customer_Phone"],
                        region = (int)reader["Region_ID"],
                        EntryDate = (DateTime)reader["Entry_Date"],
                        QuitDate = (DateTime)reader["Quit_Date"]


                    };
                    customers.Add(customer);
                }

            }
            return customers;
        }
        public void DeleteCustomer(string id)
        {
            DeleteRowFromDatabase(id);

        }

        private void DeleteRowFromDatabase(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customers WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}