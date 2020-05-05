namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pidev.forum")]
    public partial class forum
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datemessage { get; set; }

        public int dislikes { get; set; }

        public int likes { get; set; }

        [StringLength(255)]
        public string message { get; set; }

        [StringLength(255)]
        public string nometudiant { get; set; }

        [StringLength(255)]
        public string prenometudiant { get; set; }
    }
}
