namespace Simple_Auth_System_Project.Model
{
    public class ReadAllInformation1Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetReadAllInformation1> readAllInformation1 { get; set; }
    }
    public class GetReadAllInformation1
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string EmailId { get; set; }
        public string ContactNo { get; set; }
        public int Salary { get; set; }
        public string IsActive { get; set; }
    }
}
