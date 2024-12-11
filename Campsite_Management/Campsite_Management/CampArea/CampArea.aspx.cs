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

namespace Campsite_Management.CampArea
{
    public partial class CampArea : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        internal string CampAreaName;
        internal string CampAddress;
        internal string CampPhone;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindRepeater();
            }
        }



        protected void EditCampArea(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;


            Session["CampID"] = id;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT CampAreaName, CampAddress, CampPhone FROM CampArea WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Session["CampName"] = reader["CampAreaName"].ToString();
                    Session["CampAddress"] = reader["CampAddress"].ToString();
                    Session["CampPhone"] = reader["CampPhone"].ToString();
                }
            }


            Response.Redirect("EditCampArea.aspx");
        }

        protected void DeleteCampArea(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;

            CampAreaRepository campAreaRepository = new CampAreaRepository(connectionString);
            campAreaRepository.DeleteCampArea(id);

            BindRepeater();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Deleted Successfully', 'success');", true);
        }

        private void BindRepeater()
        {

            CampAreaRepository campAreaRepository = new CampAreaRepository(connectionString);
            List<CampAreas> campAreas = campAreaRepository.GetAll();

            CampAreaRepeater.DataSource = campAreas;
            CampAreaRepeater.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewCampArea.aspx");
        }
    }
}