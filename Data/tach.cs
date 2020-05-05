namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.taches")]
    public partial class tach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tach()
        {
            detailstaches = new HashSet<detailstache>();
        }

        public int id { get; set; }

        public DateTime? dateDebut { get; set; }

        public DateTime? dateEstimer { get; set; }

        public DateTime? dateFin { get; set; }

        [StringLength(255)]
        public string descriptionTache { get; set; }

        public int etat { get; set; }

        public int flagActif { get; set; }

        [StringLength(255)]
        public string nomTache { get; set; }

        public int? modules_id { get; set; }

        public int? user_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detailstache> detailstaches { get; set; }

        public virtual module module { get; set; }

        public virtual user user { get; set; }
    }
}
