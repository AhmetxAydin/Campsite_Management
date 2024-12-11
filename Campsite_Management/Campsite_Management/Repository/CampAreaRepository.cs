using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Campsite_Management.Models;

namespace Campsite_Management.Repository
{
    public class CampAreaRepository
    {
        public string connectionString;

        public CampAreaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CampAreas> GetAll()
        {
            List<CampAreas> campAreas = new List<CampAreas>();
            string query = "SELECT * FROM CampArea";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    CampAreas camp = new CampAreas
                    {
                        Id = (int)dataReader["ID"],
                        CampName = (string)dataReader["CampAreaName"],
                        CampAddress = (string)dataReader["CampAddress"],
                        CampPhone = (string)dataReader["CampPhone"]
                    };

                    campAreas.Add(camp);
                }
                connection.Close();
            }
            return campAreas;
        }

        public void DeleteCampArea(string id)
        {
            DeleteRowFromDatabase(id);
        }

        private void DeleteRowFromDatabase(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CampArea WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}