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

namespace Campsite_Management.Customer
{
    public partial class Customers : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        private readonly CustomerRepository _customerRepository;

        public Customers()
        {
            _customerRepository = new CustomerRepository(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindCustomerData();
            }
        }

        private void BindCustomerData()
        {
            List<CustomerModel> customers = _customerRepository.GetCustomers();
            CustomersRepeater.DataSource = customers;
            CustomersRepeater.DataBind();
        }



        protected void DeleteCustomer(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;

            CustomerRepository customerRepository = new CustomerRepository(connectionString);
            customerRepository.DeleteCustomer(id);
            BindCustomerData();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Deleted Successfully', 'success');", true);
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx");

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;


            Session["ID"] = id;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "SELECT Camp_ID, Plaka, First_Name, Last_Name, Region_ID, Entry_Date, Quit_Date, Customer_Phone " +
                               "FROM Customers WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Session["CampID"] = reader["Camp_ID"].ToString();
                        Session["Plaka"] = reader["Plaka"].ToString();
                        Session["FirstName"] = reader["First_Name"].ToString();
                        Session["LastName"] = reader["Last_Name"].ToString();
                        Session["RegionID"] = reader["Region_ID"].ToString();
                        Session["EntryDate"] = Convert.ToDateTime(reader["Entry_Date"]).ToString("yyyy-MM-dd");
                        Session["QuitDate"] = Convert.ToDateTime(reader["Quit_Date"]).ToString("yyyy-MM-dd");
                        Session["CustomerPhone"] = reader["Customer_Phone"].ToString();

                    }
                    else
                    {

                        Response.Write("<script>alert('Customer not found!');</script>");
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
                }
            }
            Response.Redirect("EditCustomer.aspx");
        }

    }
}