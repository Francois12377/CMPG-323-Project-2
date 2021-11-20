using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMPG_323_Project_2.Models
{
    public class UsersModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Password and Confirm Password fields must match")]
        public string confirmpass { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        
        public string Age { get; set; }

        public string Profilepic { get; set; }
    }
}
