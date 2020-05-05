namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.departement")]
    public partial class departement
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }
    }
}
