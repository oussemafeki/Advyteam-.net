using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advyteam.Models
{
    public class PosteModel
    {

        public string nom { get; set; }

        public string description { get; set; }
        public int salaire { get; set; }

        [StringLength(255)]
        public string typeContrat { get; set; }
    }
}