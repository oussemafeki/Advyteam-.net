using Domain;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Advyteam.Models
{
    public class MissionModel
    {
        public long id { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        public DateTime? dateDeb { get; set; }

        public DateTime? dateFin { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string nomMission { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public long? expense_id { get; set; }

        public int? idProject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<demande> demandes { get; set; }

        public virtual expenses expens { get; set; }

        public virtual project project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<skills> skills { get; set; }
    }
}