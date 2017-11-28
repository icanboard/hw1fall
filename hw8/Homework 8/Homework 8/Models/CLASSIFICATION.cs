namespace Homework_8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLASSIFICATIONS")]
    public partial class CLASSIFICATION
    {
        [Key]
        public int CID { get; set; }

        public int AWID { get; set; }

        [Required]
        [StringLength(24)]
        public string Genre { get; set; }

        public virtual ARTWORK ARTWORK { get; set; }

        public virtual GENRE GENRE1 { get; set; }
    }
}
