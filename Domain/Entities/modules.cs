namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.modules")]
    public partial class modules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public modules()
        {
            taches = new HashSet<taches>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string descriptionModule { get; set; }

        public int flagActif { get; set; }

        [StringLength(255)]
        public string nomModule { get; set; }

        public int? projet_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<taches> taches { get; set; }

        public virtual project project { get; set; }
    }
}
