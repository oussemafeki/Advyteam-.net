using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;


namespace timesheetPI.Models
{
    public class TachesModels
    {
        public int id { get; set; }


        public int dateEstimer { get; set; }


     
        public string descriptionTache { get; set; }

        public int etat { get; set; }


        public string nomTache { get; set; }

        public int? modules_id { get; set; }

        public int? user_id { get; set; }


        public virtual modules modules { get; set; }

        public virtual employe user { get; set; }
    }
}