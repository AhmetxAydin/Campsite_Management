using Campsite_Management.Models;
using Campsite_Management.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campsite_Management.CampMaterial
{
    public partial class CampMaterial : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void DeleteCampMaterial(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;

            CampMaterialRepository campMaterialRepository = new CampMaterialRepository(connectionString);
            campMaterialRepository.DeleteMaterial(id);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Deleted Successfully', 'success');", true);
            BindData();

        }

        protected void EditCampMaterial(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;


            Session["material_ID"] = id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaterialName, MaterialDescription, MaterialProducer FROM CampMaterial WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Session["material_Name"] = reader["MaterialName"].ToString();
                    Session["material_Description"] = reader["MaterialDescription"].ToString();
                    Session["material_Producer"] = reader["MaterialProducer"].ToString();

                }
            }


            Response.Redirect("EditCampMaterial.aspx");
        }

        public void BindData()
        {
            CampMaterialRepository campMaterialRepository = new CampMaterialRepository(connectionString);
            List<CampMaterials> campMaterials = campMaterialRepository.GetCampMaterials();

            CampMaterialRepeater.DataSource = campMaterials;
            CampMaterialRepeater.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCampMaterial.aspx");
        }
    }
}