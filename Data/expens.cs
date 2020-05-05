namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.expenses")]
    public partial class expens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public expens()
        {
            missions = new HashSet<mission>();
        }

        public long id { get; set; }

        public float? autres_frais { get; set; }

        public float? distance { get; set; }

        public float? prix_hebergement { get; set; }

        public float? prix_resto { get; set; }

        public float? prix_transport { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        public float? total { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mission> missions { get; set; }
    }
}
