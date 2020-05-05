namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.detailstache")]
    public partial class detailstache
    {
        public int id { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int nbrHeures { get; set; }

        public int? id_tache { get; set; }

        public virtual taches taches { get; set; }
    }
}
