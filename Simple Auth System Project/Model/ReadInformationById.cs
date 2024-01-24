using System.ComponentModel.DataAnnotations;

namespace Simple_Auth_System_Project.Model
{
    public class ReadInformationById
    {
        public class ReadInformationResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public List<ReadInformation> readInformation { get; set; }
        }

        public class ReadInformation
        {
            public int EmpId { get; set; }
            public string Name { get; set; }
            public string Age { get; set; }
            public string EmailId { get; set; }
            public string ContactNo { get; set; }
            public int Salary { get; set; }
            public string IsActive { get; set; }
        }

        public class ReadInformationByIdRequest
        {
            [Required]
            public int EmpId { get; set; }
        }

        public class ReadInformationByIdResponse
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; }
            public ReadInformation readInformation { get; set; }
        }
    }
}
