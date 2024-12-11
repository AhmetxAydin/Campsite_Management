using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Campsite_Management.Models;

namespace Campsite_Management.Models
{
    public class CampMaterials
    {
        public int material_Id { get; set; }
        public string material_Name { get; set; }
        public string material_Description { get; set; }
        public string material_Producer { get; set; }
    }
}
