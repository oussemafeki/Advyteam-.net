namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.affectationproject")]
    public partial class affectationproject
    {
        public int id { get; set; }

        public DateTime? dateAffectation { get; set; }

        public DateTime? dateFin { get; set; }

        public int? projetaffectation_id { get; set; }

        public int? useraffectation_id { get; set; }

        public virtual project project { get; set; }

        public virtual employe employe { get; set; }
    }
}
