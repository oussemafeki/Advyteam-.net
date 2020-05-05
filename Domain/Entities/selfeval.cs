namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.selfeval")]
    public partial class selfeval
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public int? employe { get; set; }

        public int? value { get; set; }

        public int critere_id { get; set; }

        public virtual critere critere { get; set; }
    }
}
