using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campsite_Management.Models
{
    public class CampActivities
    {
        public int Id { get; set; }
        public int Camp_ID { get; set; }
        public string Activity_Name { get; set; }
        public string Activity_Description { get; set; }
    }
}