using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campsite_Management.Customer
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateCampAreaDropDownList(CampAreas);
                PopulateRegionDropDownList(ddlRegion);
            }
        }

        protected void btnSAVE_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string campID = CampAreas.SelectedValue;
            string plaka = this.plaka.Text;
            string regionID = ddlRegion.SelectedValue;
            string phone = txtPhone.Text;

            DateTime entryDate;
            DateTime quitDate;

            bool isEntryDateValid = DateTime.TryParseExact(txtEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out entryDate);
            bool isQuitDateValid = DateTime.TryParseExact(txtQuitDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out quitDate);

            if (string.IsNullOrEmpty(campID) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(plaka) || string.IsNullOrEmpty(regionID) || !isEntryDateValid || !isQuitDateValid)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('No field can be left blank!', 'warning');", true);
                return;
            }

            string query = "INSERT INTO Customers (Camp_ID, Plaka, First_Name, Last_Name,Customer_Phone, Region_ID, Entry_Date, Quit_Date) VALUES (@campID, @plaka, @firstName, @lastName,@phone, @regionID, @entryDate, @quitDate)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@campID", campID);
                    command.Parameters.AddWithValue("@plaka", plaka);
                    command.Parameters.AddWithValue("@firstName", firstName);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@regionID", regionID);
                    command.Parameters.AddWithValue("@entryDate", entryDate);
                    command.Parameters.AddWithValue("@quitDate", quitDate);


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();


                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Customer added successfully!', 'success');", true);
                        Response.Redirect("Customers.aspx");
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('An error occurred: " + ex.Message + "', 'error');", true);
                        return;
                    }
                }
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

        private void PopulateRegionDropDownList(DropDownList ddlRegion)
        {
            string query = "SELECT RegionID, Description FROM Region";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ddlRegion.DataSource = dataTable;
                ddlRegion.DataValueField = "RegionID";
                ddlRegion.DataTextField = "Description";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("Select a Region", "0"));

                connection.Close();
            }
        }
    }
}