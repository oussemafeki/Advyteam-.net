namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.training")]
    public partial class training
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public training()
        {
            employe = new HashSet<employe>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime? date { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int nbplace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employe> employe { get; set; }
    }
}
