using System.ComponentModel.DataAnnotations;

namespace Simple_Auth_System_Project.Model
{
    public class SignInRequest
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
    public class SignInResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

}
