using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KPITEA.Entities.DataModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Fist Name")]
        public string FistName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Age")]
        public byte Age { get; set; }

        [Required]
        [Display(Name = "MaritalStatus")]
        public bool MaritalStatus { get; set; }

        [Required]
        [Display(Name = "Salary")]
        public decimal Salary { get; set; }

        [Required]
        [Display(Name = "Location")]
        public String Location { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

}
