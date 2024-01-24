using System.ComponentModel.DataAnnotations;

namespace Simple_Auth_System_Project.Model
{
    public class DeleteEmpDetailsRequest
    {
        public int EmpId { get; set; }
    }
    public class DeleteEmpDetailsResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
