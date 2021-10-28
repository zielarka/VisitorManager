using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VisitorManager.Infrastructure.Commands.User
{
    public class CreateUser
    {
        public Guid id { get; set; } 

        [Required(ErrorMessage = "Username is required.")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required ")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Passwords must be between 6 and 12 characters long.")]
        public string password { get; set; }
    }
}
