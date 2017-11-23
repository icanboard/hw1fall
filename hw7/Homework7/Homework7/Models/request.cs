namespace Homework7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("REQUESTS")]
    public partial class Request
    {
        [Key]
        public int RID { get; set; }

        public DateTime RequestDate { get; set; }

        [Required]
        [StringLength(64)]
        public string RequestString { get; set; }

        [Required]
        [StringLength(15)]
        public string Rating { get; set; }

        [Required]
        [StringLength(64)]
        public string UserIP { get; set; }

        [Required]
        [StringLength(128)]
        public string UserAgent { get; set; }
    }
}
