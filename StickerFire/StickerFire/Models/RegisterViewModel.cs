using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Models
{
    //Model for the Register portion of the login/register view
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "You do not meet the password requirements", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The passwords do not match!!")]
        public string ConfirmPassword { get; set; }
    }
}
