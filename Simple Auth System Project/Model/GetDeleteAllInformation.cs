namespace Simple_Auth_System_Project.Model
{
    public class GetDeleteAllInformationResponse
    {
        public bool IsSuccess {  get; set; }
        public string Message {  get; set; }

        public List<GetDeleteAllInformation> getDeleteAllInformation { get; set; }
               
    }
    public class GetDeleteAllInformation 
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
