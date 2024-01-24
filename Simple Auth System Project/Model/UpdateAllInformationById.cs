using System.ComponentModel.DataAnnotations;

namespace Simple_Auth_System_Project.Model
{
    public class UpdateAllInformationByIdRequest
    {
        [Required(ErrorMessage = "EmpId is Required")]
        public int EmpId { get; set; }

        //[Required(ErrorMessage = "Name is  mandatory field")]
        public string Name { get; set; }

        //[Required]
        public string Age { get; set; }

        //[Required]
        //[RegularExpression(pattern: "[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}", ErrorMessage = "Email Not in valid format")]
        public string EmailId { get; set; }

        //[Required]
        //[RegularExpression(pattern: "([1-9]{1}[0-9]{9})$", ErrorMessage = "ContactNo Not in valid format")]
        public string ContactNo { get; set; }

        //[Required(ErrorMessage = "Salary is  mandatory field")]
        //[Range(minimum: 1000, int.MaxValue, ErrorMessage = "Please Enter Salary greator than 0")]
        public int Salary { get; set; }
    }
    public class UpdateAllInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }

}
