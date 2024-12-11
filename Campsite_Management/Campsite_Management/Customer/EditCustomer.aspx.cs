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
    public partial class EditCustomer : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string campID = Session["CampID"] as string;
            string plaka = Session["Plaka"] as string;
            string firstName = Session["FirstName"] as string;
            string lastName = Session["LastName"] as string;
            string region = Session["RegionID"] as string;
            string entry = Session["EntryDate"] as string;
            string quit = Session["QuitDate"] as string;
            string phone = Session["CustomerPhone"] as string;


            if (!IsPostBack)
            {
                PopulateCampAreaDropDownList(CampAreas);
                PopulateRegionDropDownList(ddlRegion);

                txtFirstName.Text = firstName;
                txtLastName.Text = lastName;
                txtEntryDate.Text = entry;
                txtQuitDate.Text = quit;
                txtPhone.Text = phone;
                CampAreas.Text = campID;
                ddlRegion.Text = region;
                txtlicanceplate.Text = plaka;

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

        public void Btn_Save(object sender, EventArgs e)
        {
            string first_name = txtFirstName.Text.Trim();
            string last_name = txtLastName.Text.Trim();
            string customer_phone = txtPhone.Text.Trim();
            string licance_plate = txtlicanceplate.Text.Trim();
            string camp_ID = CampAreas.SelectedValue;
            string region = ddlRegion.SelectedValue;
            DateTime entryDate;
            DateTime quitDate;

            bool isEntryDateValid = DateTime.TryParseExact(txtEntryDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out entryDate);
            bool isQuitDateValid = DateTime.TryParseExact(txtQuitDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out quitDate);


            string sessionFirstName = Session["FirstName"].ToString().Trim();
            string sessionLastName = Session["LastName"].ToString().Trim();
            string sessionPhone = Session["CustomerPhone"].ToString().Trim();
            string sessionPlaka = Session["Plaka"].ToString().Trim();
            string sessionEntryDate = Session["EntryDate"].ToString().Trim();
            string sessionQuitDate = Session["QuitDate"].ToString().Trim();
            string sessionRegion = Session["RegionID"].ToString().Trim();
            string sessionCampID = Session["CampID"].ToString().Trim();

            bool isFirstNameChanged = !first_name.Equals(sessionFirstName, StringComparison.OrdinalIgnoreCase);
            bool isLastNameChanged = !last_name.Equals(sessionLastName, StringComparison.OrdinalIgnoreCase);
            bool isPhoneChanged = !customer_phone.Equals(sessionPhone, StringComparison.OrdinalIgnoreCase);
            bool isPlakaChanged = !licance_plate.Equals(sessionPlaka, StringComparison.OrdinalIgnoreCase);
            bool isEntryDateChanged = !txtEntryDate.Text.Equals(sessionEntryDate, StringComparison.OrdinalIgnoreCase);
            bool isQuitDateChanged = !txtQuitDate.Text.Equals(sessionQuitDate, StringComparison.OrdinalIgnoreCase);
            bool isRegionChanged = !region.Equals(sessionRegion, StringComparison.OrdinalIgnoreCase);
            bool isCampIDChanged = !camp_ID.Equals(sessionCampID, StringComparison.OrdinalIgnoreCase);

            if (string.IsNullOrEmpty(first_name) || string.IsNullOrEmpty(last_name) | string.IsNullOrEmpty(customer_phone) || string.IsNullOrEmpty(licance_plate) || !isEntryDateValid || !isQuitDateValid)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('No field can be left blank!', 'warning');", true);
                return;
            }
            if (camp_ID == "0" || region == "0")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Please select valid options for Camp Area and Region.', 'warning');", true);
                return;
            }

            else if (!isFirstNameChanged && !isLastNameChanged && !isPhoneChanged && !isPlakaChanged && !isEntryDateChanged && !isQuitDateChanged && !isCampIDChanged && !isRegionChanged)
            {
                Response.Redirect("Customers.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Does not make any change' , 'info');", true);
            }

            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customers SET";
                    List<string> values = new List<string>();

                    if (isFirstNameChanged)
                        values.Add("First_Name = @first_name");
                    if (isLastNameChanged)
                        values.Add("Last_Name = @last_name");
                    if (isPhoneChanged)
                        values.Add("Customer_Phone = @customer_phone");
                    if (isPlakaChanged)
                        values.Add("Plaka = @licance_plate");
                    if (isPhoneChanged)
                        values.Add("Customer_Phone = @customer_phone");
                    if (isEntryDateChanged)
                        values.Add("Entry_Date = @EntryDate");
                    if (isQuitDateChanged)
                        values.Add("Quit_Date  = @QuitDate");
                    if (isCampIDChanged)
                        values.Add("Camp_ID = @camp_ID");
                    if (isRegionChanged)
                        values.Add("Region_ID = @region");

                    query += " " + string.Join(",", values) + " WHERE ID = @ID";


                    SqlCommand cmd = new SqlCommand(query, connection);
                    if (isFirstNameChanged)
                        cmd.Parameters.AddWithValue("@first_name", first_name);
                    if (isLastNameChanged)
                        cmd.Parameters.AddWithValue("@last_name", last_name);
                    if (isPhoneChanged)
                        cmd.Parameters.AddWithValue("@customer_phone", customer_phone);
                    if (isPlakaChanged)
                        cmd.Parameters.AddWithValue("@licance_plate", licance_plate);
                    if (isPhoneChanged)
                        cmd.Parameters.AddWithValue("@customer_phone", customer_phone);
                    if (isEntryDateChanged)
                        cmd.Parameters.AddWithValue("@entryDate", entryDate);
                    if (isQuitDateChanged)
                        cmd.Parameters.AddWithValue("@quitDate", quitDate);
                    if (isCampIDChanged)
                        cmd.Parameters.AddWithValue("@camp_ID", camp_ID);
                    if (isRegionChanged)
                        cmd.Parameters.AddWithValue("@region", region);


                    cmd.Parameters.AddWithValue("@ID", Session["ID"]);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();


                }
                Response.Redirect("Customers.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('All Changes Saved Successfully', 'success')", true);
            }
        }
    }
}