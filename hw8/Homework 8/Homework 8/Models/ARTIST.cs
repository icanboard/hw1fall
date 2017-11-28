namespace Homework_8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTISTS")]
    public partial class ARTIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTIST()
        {
            ARTWORKS = new HashSet<ARTWORK>();
        }

        [Key]
        public int AID { get; set; }

        [Required]
        [StringLength(50)]
        public string ArtistName { get; set; }

        [Required]
        [StringLength(50)]
        public string BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string BirthCity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTWORK> ARTWORKS { get; set; }
    }
}
