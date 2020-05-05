using System;
using Domain;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace timesheetPI.Models
{

    public class ProjectModels
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int flagActif { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? dateDebutProjet { get; set; }
    }

    
}