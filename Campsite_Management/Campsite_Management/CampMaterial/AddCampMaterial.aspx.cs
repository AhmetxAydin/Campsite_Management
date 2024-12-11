using Campsite_Management.Models;
using Campsite_Management.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Campsite_Management.CampMaterial
{
    public partial class AddCampMaterial : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSAVE_Click(object sender, EventArgs e)
        {
            string name = Material_Name.Text;
            string description = Material_Description.Text;
            string producer = Material_Producer.Text;

            if ((name == "") || (description == "") || (producer == ""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('No field can be left blank!', 'warning');", true);
            }
            else
            {
                try
                {
                    CampMaterialRepository campMaterialRepository = new CampMaterialRepository(connectionString);
                    CampMaterials material = new CampMaterials
                    {
                        material_Name = name,
                        material_Producer = producer,
                        material_Description = description,
                    };
                    campMaterialRepository.AddCampMaterial(material);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Saved Successfully', 'success');", true);
                    Response.Redirect("CampMaterial.aspx");
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert(" + ex.Message + ", 'warning');", true);
                    return;
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert('Record Saved Successfully', 'success');", true);
            Response.Redirect("CampMaterial.aspx");

        }
    }
}