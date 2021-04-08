using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace PoulSite.Models
{
    public class ContactForm
    {
        [Key]
        public int CustNo { get; set; } 

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required(ErrorMessage = "Required.")]
        public EGender Gender { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Barangay { get; set; }

        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Additional Address  (Building/Unit No./Street/etc.)")]
        public string CompleteAddress { get; set; }
    }

    public enum EGender{ 
        Male = 1,
        Female = 2
    }
}
