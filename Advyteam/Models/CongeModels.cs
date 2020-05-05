
using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advyteam.Models
{
    public class CongeModels
    {

        public int id { get; set; }

        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string demandeConge { get; set; }
        public string typeConge { get; set; }
        public string reponse { get; set; }
        public string certefica { get; set; }
        public int nbr_jr { get; set; }
        public string status { get; set; }
        public employe employes { get; set; }

    }
}