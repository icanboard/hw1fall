namespace Homework_8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTWORKS")]
    public partial class ARTWORK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTWORK()
        {
            CLASSIFICATIONS = new HashSet<CLASSIFICATION>();
        }

        [Key]
        public int AWID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int AID { get; set; }

        public virtual ARTIST ARTIST { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASSIFICATION> CLASSIFICATIONS { get; set; }
    }
}
