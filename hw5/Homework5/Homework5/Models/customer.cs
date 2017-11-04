using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class Customer
    {
        [Key]
        public int CID { get; set; }

        [Required]
        public string ODL { get; set; }
        
        [Required, StringLength(10)]
        [Display(Name ="Date of Birth")]
        public string DOB { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Street")]
        public string StreetAdd { get; set; }

        [Required, StringLength(24)]
        [Display(Name = "City")]
        public string CityAdd { get; set; }

        [Required, StringLength(3)]
        [Display(Name = "State")]
        public string StateAdd { get; set; }

        [Required, StringLength(5)]
        [Display(Name = "Zip")]
        public string ZipAdd { get; set; }

        [Required, StringLength(2)]
        [Display(Name = "County")]
        public string CountyAdd { get; set; }
        
        [StringLength(10)]
        [Display(Name = "Date Signed")]
        public string DateSigned { get; set; }
    }
}