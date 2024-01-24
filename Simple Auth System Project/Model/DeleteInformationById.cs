using System.ComponentModel.DataAnnotations;

namespace Simple_Auth_System_Project.Model
{
    public class DeleteInformationByIdRequest
    {
        [Required(ErrorMessage = "EmpId is Required")]
        public int EmpId { get; set; }

    }
    public class DeleteInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
