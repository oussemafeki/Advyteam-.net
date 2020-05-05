namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.taches")]
    public partial class taches
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taches()
        {
            detailstache = new HashSet<detailstache>();
        }

        public int id { get; set; }

        public DateTime? dateDebut { get; set; }

        public int dateEstimer { get; set; }

        public DateTime? dateFin { get; set; }

        [StringLength(255)]
        public string descriptionTache { get; set; }

        public int etat { get; set; }

        public int flagActif { get; set; }

        [StringLength(255)]
        public string nomTache { get; set; }

        public int? employe_id { get; set; }

        public int? modules_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailstache> detailstache { get; set; }

        public virtual employe employe { get; set; }

        public virtual modules modules { get; set; }
    }
}
