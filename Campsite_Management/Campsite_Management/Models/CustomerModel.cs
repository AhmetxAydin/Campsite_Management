using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Campsite_Management.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int CampId { get; set; }

        public string plaka { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string customerPhone { get; set; }
        public int region { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime QuitDate { get; set; }
    }
}