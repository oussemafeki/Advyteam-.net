namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.demande")]
    public partial class demande
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
