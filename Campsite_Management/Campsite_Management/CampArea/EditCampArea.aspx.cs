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
    public partial class EditCampArea : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string campID = Session["CampID"] as string;
            string campName = Session["CampName"] as string;
            string campAddress = Session["CampAddress"] as string;
            string campPhone = Session["CampPhone"] as string;

            if (!IsPostBack)
            {
                CampArea_Name.Text = campName;
                CampArea_Address.Text = campAddress;
                Camp_Phone.Text = campPhone;
            }
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string Name = CampArea_Name.Text.Trim();
            string Address = CampArea_Address.Text.Trim();
            string Phone = Camp_Phone.Text.Trim();

            string sessionName = Session["CampName"].ToString().Trim();
            string sessionAddress = Session["CampAddress"].ToString().Trim();
            string sessionPhone = Session["CampPhone"].ToString().Trim();

            bool isNameChanged = !Name.Equals(sessionName, StringComparison.OrdinalIgnoreCase);
            bool isAddressChanged = !Address.Equals(sessionAddress, StringComparison.OrdinalIgnoreCase);
            bool isPhoneChanged = !Phone.Equals(sessionPhone, StringComparison.OrdinalIgnoreCase);

            if (!isNameChanged && !isAddressChanged && !isPhoneChanged)
            {
                Response.Redirect("CampArea.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Does not make any change' , 'info');", true);
            }

            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CampArea SET ";
                    List<string> updates = new List<string>();

                    if (isNameChanged)
                        updates.Add("CampAreaName = @Name");
                    if (isAddressChanged)
                        updates.Add("CampAddress = @Address");
                    if (isPhoneChanged)
                        updates.Add("CampPhone = @Phone");

                    query += string.Join(", ", updates) + " WHERE ID = @ID";

                    SqlCommand cmd = new SqlCommand(query, connection);

                    if (isNameChanged)
                        cmd.Parameters.AddWithValue("@Name", Name);
                    if (isAddressChanged)
                        cmd.Parameters.AddWithValue("@Address", Address);
                    if (isPhoneChanged)
                        cmd.Parameters.AddWithValue("@Phone", Phone);

                    cmd.Parameters.AddWithValue("@ID", Session["CampID"]);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                Response.Redirect("CampArea.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('All Changes Saved Successfully', 'success')", true);
            }
        }
    }
}