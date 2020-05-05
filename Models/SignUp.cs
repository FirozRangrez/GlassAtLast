using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlassProject.Models
{
    public class SignUp
    {
        public int id { get; set; }
        [Required(ErrorMessage = "*Name is Required")]
        public string MName { get; set; }
        [Required(ErrorMessage = "*Gender is Required")]
        public string MGender { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "*Mail Address is Required")]
        public string MMail{ get; set; }
        [Required(ErrorMessage = "*Mobile Number is Required")]
        //[RegularExpression(@"^(\d{0-9})$", ErrorMessage = "Wrong mobile")]
        public string MMobileNumber { get; set; }

        [Required(ErrorMessage = "*BuildingNumber is Required")]
        public string MBuildingNumber { get; set; }

        [Required(ErrorMessage = "*Landmark is Required")]
        public string MLandmark { get; set; }

        [Required(ErrorMessage = "* State is Required")]
        public string Mstate { get; set; }

        [Required(ErrorMessage ="* City is required")]
        public string Mcity { get; set; }

        [Required(ErrorMessage = "*Pincode is Required")]
        public int? MPincode { get; set; }

        [Required(ErrorMessage = "*Password is Required")]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character")]
        public string MPassword { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare("MPassword", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string MCnfPassword { get; set; }

        public string size { get; set; }

    }
}