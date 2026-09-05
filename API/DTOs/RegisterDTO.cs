using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDTO
    {
          public  string DisplayName { get; set; }="";
          [EmailAddress ]
          [Required]

        public  string Email { get; set; }="";
[Required]
[MinLength(6, ErrorMessage = "Password must be at least 6 characters long.") ]
        public  string Password { get; set; }   ="";
    }
}