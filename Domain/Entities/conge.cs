namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.conge")]
    public partial class conge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public conge()
        {
            employe = new HashSet<employe>();
        }

        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateDebut { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateFin { get; set; }

        [StringLength(255)]
        public string certefica { get; set; }

        [StringLength(255)]
        public string demandeConge { get; set; }

        public int nbr_jr { get; set; }

        [StringLength(255)]
        public string reponse { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string typeConge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employe> employe { get; set; }
    }
}
