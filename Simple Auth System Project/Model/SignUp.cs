﻿using System.ComponentModel.DataAnnotations;

namespace Simple_Auth_System_Project.Model
{
    public class SignUpRequest
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]    
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

    }
    public class SignUpResponse
    {
        public bool IsSuccess { get; set;}
        public string Message { get; set;}

        
    }
}
