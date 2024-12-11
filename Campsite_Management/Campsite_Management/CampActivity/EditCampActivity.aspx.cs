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
    public partial class EditCampActivity : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string campID = Session["Camp_ID"] as string;
            string activity_name = Session["activity_name"] as string;
            string description_activity = Session["description_activity"] as string;

            if (!IsPostBack)
            {
                PopulateCampAreaDropDownList(CampAreas);

                CampAreas.Text = campID;
                CampActivity.Text = activity_name;
                ActivityDescription.Text = description_activity;
            }
        }

        private void PopulateCampAreaDropDownList(DropDownList ddlCampArea)
        {

            string query = "SELECT ID, CampAreaName FROM CampArea";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ddlCampArea.DataSource = reader;
                ddlCampArea.DataValueField = "ID";
                ddlCampArea.DataTextField = "CampAreaName";
                ddlCampArea.DataBind();

                ddlCampArea.Items.Insert(0, new ListItem("Select a Camp Area", "0"));

                reader.Close();
                connection.Close();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CampActivityRepository campActivityRepository = new CampActivityRepository(connectionString);

                CampActivities updateactivity = new CampActivities
                {
                    Id = int.Parse(Session["activity_ID"].ToString()),
                    Camp_ID = int.Parse(CampAreas.SelectedValue),
                    Activity_Name = CampActivity.Text,
                    Activity_Description = ActivityDescription.Text
                };

                campActivityRepository.UpdateActivity(updateactivity);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Updated Successfully', 'success');", true);
                Response.Redirect("campActivity.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert(" + ex.Message + ", 'warning');", true);
                return;
            }
        }
    }
}