using Campsite_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Campsite_Management.Repository
{
    public class CampMaterialRepository
    {
        public string connectionString;

        public CampMaterialRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CampMaterials> GetCampMaterials()
        {
            List<CampMaterials> materials = new List<CampMaterials>();

            string query = "SELECT * FROM CampMaterial";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CampMaterials material = new CampMaterials
                    {
                        material_Id = (int)reader["ID"],
                        material_Name = (string)reader["MaterialName"],
                        material_Description = (string)reader["MaterialDescription"],
                        material_Producer = (string)reader["MaterialProducer"]
                    };
                    materials.Add(material);
                }
                connection.Close();

            }
            return materials;
        }

        public void AddCampMaterial(CampMaterials material)
        {
            string query = "Insert Into CampMaterial (MaterialName , MaterialDescription, MaterialProducer) Values (@name , @description , @producer)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", material.material_Name);
                command.Parameters.AddWithValue("@description", material.material_Description);
                command.Parameters.AddWithValue("@producer", material.material_Producer);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateMaterial(CampMaterials material)
        {
            string query = "UPDATE CampMaterial SET MaterialName = @material_Name, MaterialDescription = @material_Description, MaterialProducer = @material_Producer WHERE ID = @material_Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@material_Id", material.material_Id);
                command.Parameters.AddWithValue("@material_Name", material.material_Name);
                command.Parameters.AddWithValue("@material_Description", material.material_Description);
                command.Parameters.AddWithValue("@material_Producer", material.material_Producer);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteMaterial(string id)
        {
            DeleteRowFromDatabase(id);
        }

        private void DeleteRowFromDatabase(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CampMaterial WHERE ID = @ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}