using Campsite_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Campsite_Management.Repository
{
    public class CampActivityRepository
    {
        public string connectionString;

        public CampActivityRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CampActivities> GetAll()
        {
            List<CampActivities> campActivities = new List<CampActivities>();
            string query = "SELECT * FROM CampActivity";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CampActivities activity = new CampActivities
                    {
                        Id = (int)reader["ID"],
                        Camp_ID = (int)reader["CampId"],
                        Activity_Name = (string)reader["ActivityName"],
                        Activity_Description = (string)reader["DescriptionActivity"]

                    };
                    campActivities.Add(activity);
                }
                connection.Close();
            }
            return campActivities;
        }


        public void AddCampActivity(CampActivities activity)
        {
            string query = "INSERT INTO CampActivity (CampId, ActivityName , DescriptionActivity) VALUES (@campId , @activity_name , @activity_description )";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@campId", activity.Camp_ID);
                cmd.Parameters.AddWithValue("@activity_name", activity.Activity_Name);
                cmd.Parameters.AddWithValue("@activity_description", activity.Activity_Description);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateActivity(CampActivities activity)
        {
            string query = "UPDATE CampActivity SET CampId = @Camp_ID , ActivityName = @Activity_Name, DescriptionActivity = @Activity_Description WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", activity.Id);
                command.Parameters.AddWithValue("@Camp_ID", activity.Camp_ID);
                command.Parameters.AddWithValue("@Activity_Name", activity.Activity_Name);
                command.Parameters.AddWithValue("@Activity_Description", activity.Activity_Description);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        public void DeleteActivity(string id)
        {
            DeleteRowFromDatabase(id);

        }

        private void DeleteRowFromDatabase(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CampActivity WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}