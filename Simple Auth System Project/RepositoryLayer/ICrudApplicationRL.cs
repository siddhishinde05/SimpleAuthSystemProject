using Simple_Auth_System_Project.Model;
using static Simple_Auth_System_Project.Model.ReadInformationById;

namespace Simple_Auth_System_Project.RepositoryLayer
{
    public interface ICrudApplicationRL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<ReadAllInformationResponse> ReadAllInformation();
        //public Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request);
        public Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request);
        public Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request);
        public Task<GetDeleteAllInformationResponse> GetDeleteAllInformation();


    }
}
