using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Advyteam.Models
{
    [System.Runtime.InteropServices.ComVisible(true)]
    [System.Serializable]
    public class ManagerEvalModel
    {
        public ManagerEvalModel()
        {
            Categories = new SelectList("Empty",""); 
        }
           

        [StringLength(255)]
        public string description { get; set; }
        public string NomEmploye { get; set; }
        public string NomCritere { get; set; }

        public int? value { get; set; }

        public int critere_id { get; set; }

        public int employe_id { get; set; }

        public virtual critere critere { get; set; }

        public virtual employe employe { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

       
    }
}