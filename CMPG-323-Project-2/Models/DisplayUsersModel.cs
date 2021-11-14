using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CMPG_323_Project_2.Models
{
    public class DisplayUsersModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
