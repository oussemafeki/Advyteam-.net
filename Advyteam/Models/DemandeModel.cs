﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Domain;

namespace Advyteam.Models
{


    [Table("pidev.demande")]
    public  class DemandeModel
    {
        public long id { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [Column(TypeName = "bit")]
        public bool? isValide { get; set; }

        public int? employe_id { get; set; }

        public long? mission_id { get; set; }

        public virtual mission mission { get; set; }

        public virtual employe employe { get; set; }
    }
}
