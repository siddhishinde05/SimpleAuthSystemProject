using Simple_Auth_System_Project.Model;

namespace Simple_Auth_System_Project.DataAccessLayer
{
    public interface IAuthDL
    {
       public Task<SignUpResponse>SignUp(SignUpRequest request);
       public Task<SignInResponse> SignIn(SignInRequest request);
       public Task<AddInformation1Response> AddInformation1(AddInformation1Request request);
       public Task<ReadAllInformation1Response> ReadAllInformation1(int EmpId);
       public Task<UpdateAllInformationById1Response> UpdateAllInformationById1(UpdateAllInformationById1Request request);
       public Task<DeleteInformationById1Response> DeleteInformationById1(DeleteInformationById1Request request);       
       public Task<DeleteEmpDetailsResponse> DeleteEmpDetails(DeleteEmpDetailsRequest request, int EmpId);
    }
}
