using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advyteam.Models
{
    public class EmployeModels
    {

        [Key]
        public int id { get; set; }

        public string email { get; set; }

        public bool? actif { get; set; }

        public string nom { get; set; }

        public string password { get; set; }

        public string prenom { get; set; }

        public string role { get; set; }
    }
}