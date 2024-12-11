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
    public partial class EditCampMaterial : System.Web.UI.Page
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string material_name = Session["material_Name"] as string;
            string material_description = Session["material_Description"] as string;
            string materil_producer = Session["material_Producer"] as string;

            if (!IsPostBack)
            {
                Material_Name.Text = material_name;
                Material_Description.Text = material_description;
                Material_Producer.Text = materil_producer;
            }

        }

        protected void btnSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                CampMaterialRepository materialRepository = new CampMaterialRepository(connectionString);

                CampMaterials updatedMaterial = new CampMaterials
                {
                    material_Name = Material_Name.Text,
                    material_Description = Material_Description.Text,
                    material_Producer = Material_Producer.Text,
                    material_Id = int.Parse(Session["material_ID"].ToString())
                };

                materialRepository.UpdateMaterial(updatedMaterial);
                Response.Redirect("CampMaterial.aspx");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "showAlert(" + ex.Message + ", 'warning');", true);
                return;
            }
        }
    }
}