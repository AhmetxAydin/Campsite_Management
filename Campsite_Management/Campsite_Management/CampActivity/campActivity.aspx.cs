using Campsite_Management.Repository;
using Campsite_Management.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campsite_Management.CampActivity
{
    public partial class campActivity : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }



        private void BindData()
        {
            CampActivityRepository campActivityRepository = new CampActivityRepository(connectionString);
            List<CampActivities> campActivities = campActivityRepository.GetAll();

            CampActivityRepeater.DataSource = campActivities;
            CampActivityRepeater.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;

            Session["activity_ID"] = id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CampId , ActivityName , DescriptionActivity FROM CampActivity WHERE ID =@ID ";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Session["Camp_ID"] = reader["CampID"].ToString();
                    Session["activity_name"] = reader["ActivityName"].ToString();
                    Session["description_activity"] = reader["DescriptionActivity"].ToString();
                }
            }
            Response.Redirect("EditCampActivity.aspx");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;

            CampActivityRepository campActivityRepository = new CampActivityRepository(connectionString);
            campActivityRepository.DeleteActivity(id);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Deleted Successfully', 'success');", true);
            BindData();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCampActivity.aspx");
        }
    }
}