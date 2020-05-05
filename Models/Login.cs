using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlassProject.Models
{
    public class Login
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Email Address is Required")]
        [EmailAddress]
        public string LoginEmailAddress { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string LoginPassword { get; set; }
    }
}