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
    public partial class AddNewCampArea : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void btnSave_Click(object sender, EventArgs e)
        {
            string Name = CampArea_Name.Text;
            string Address = CampArea_Address.Text;
            string Phone = Camp_Phone.Text;

            if ((Name == "") || (Address == "") || (Phone == ""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('No field can be left blank!', 'warning');", true);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO CampArea (CampAreaName, CampAddress , CampPhone) VALUES (@Name , @Address , @Phone)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Phone", Phone);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            Response.Redirect("CampArea.aspx");
        }
    }
}