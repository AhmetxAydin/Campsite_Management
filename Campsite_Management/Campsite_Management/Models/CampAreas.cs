using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Campsite_Management.Models;

namespace Campsite_Management.Models
{
    public class CampAreas
    {
        public int Id { get; set; }
        public string CampName { get; set; }
        public string CampAddress { get; set; }
        public string CampPhone { get; set; }
    }
}