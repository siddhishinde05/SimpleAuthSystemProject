using Azure.Core;
using Simple_Auth_System_Project.Model;
using Simple_Auth_System_Project.RepositoryLayer;
using System.Text.RegularExpressions;
using static Simple_Auth_System_Project.Model.ReadInformationById;

namespace Simple_Auth_System_Project.ServiceLayer
{
    public class CrudApplicationSL : ICRUDApplicationSL
    {
        public readonly ICrudApplicationRL _crudApplicationRL;
        public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string Contactregex = @"([1-9]{1}[0-9]{9})$";
        public readonly ILogger<CrudApplicationSL> _logger;
        public CrudApplicationSL(ICrudApplicationRL crudApplicationRL,ILogger<CrudApplicationSL> logger)
        {
            _crudApplicationRL = crudApplicationRL; 
            _logger = logger;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();
            if (String.IsNullOrEmpty(request.Name))
            {
                response.IsSuccess = false;
                response.Message = "Name can't be Empty";
                return response;
            }

            if (String.IsNullOrEmpty(request.Age))
            {
                response.IsSuccess = false;
                response.Message = "Age can't be Empty";
                return response;
            }
            if (String.IsNullOrEmpty(request.EmailId))
            {
                response.IsSuccess = false;
                response.Message = "EmailId can't be Empty";
                return response;
            }
            else
            {
                if (!(Regex.IsMatch(request.EmailId, EmailRegex)))
                {
                    response.IsSuccess = false;
                    response.Message = "Email Id not in correct format";
                    return response;
                }
            }
            if (String.IsNullOrEmpty(request.ContactNo))
            {
                response.IsSuccess = false;
                response.Message = "ContactNo can't be Empty";
                return response;
            }
            else
            {
                if (!(Regex.IsMatch(request.ContactNo, Contactregex)))
                {
                    response.IsSuccess = false;
                    response.Message = "ContactNo not in correct format";
                    return response;
                }
            }

            if (request.Salary <= 0)
            {
                response.IsSuccess = false;
                response.Message = "Salary can't be less than 0";
                return response;
            }
            _logger.LogInformation(message: "AddInformation Moethod is calling in service layer");
            return await _crudApplicationRL.AddInformation(request);
        }

        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation(message: "DeleteInformationById Moethod is calling in service layer");
            return await _crudApplicationRL.DeleteInformationById(request);
        }

        public async Task<GetDeleteAllInformationResponse> GetDeleteAllInformation()
        {
            _logger.LogInformation(message: "GetDeleteAllInformation Moethod is calling in service layer");
            return await _crudApplicationRL.GetDeleteAllInformation();
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            _logger.LogInformation(message: "ReadAllInformation Moethod is calling in service layer");
            return await _crudApplicationRL.ReadAllInformation();
        }

        public Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            if (String.IsNullOrEmpty(request.Name))
            {
                response.IsSuccess = false;
                response.Message = "Name can't be Empty";
                return response;
            }

            if (String.IsNullOrEmpty(request.Age))
            {
                response.IsSuccess = false;
                response.Message = "Age can't be Empty";
                return response;
            }
            if (String.IsNullOrEmpty(request.EmailId))
            {
                response.IsSuccess = false;
                response.Message = "EmailId can't be Empty";
                return response;
            }
            else
            {
                if (!(Regex.IsMatch(request.EmailId, EmailRegex)))
                {
                    response.IsSuccess = false;
                    response.Message = "Email Id not in correct format";
                    return response;
                }
            }
            if (String.IsNullOrEmpty(request.ContactNo))
            {
                response.IsSuccess = false;
                response.Message = "ContactNo can't be Empty";
                return response;
            }
            else
            {
                if (!(Regex.IsMatch(request.ContactNo, Contactregex)))
                {
                    response.IsSuccess = false;
                    response.Message = "ContactNo not in correct format";
                    return response;
                }
            }

            if (request.Salary <= 0)
            {
                response.IsSuccess = false;
                response.Message = "Salary can't be less than 0";
                return response;
            }

            _logger.LogInformation(message: "UpdateAllInformationById Moethod is calling in service layer");
            return await _crudApplicationRL.UpdateAllInformationById(request);
        }

        //public async Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request)
        //{
        //    _logger.LogInformation(message: "ReadInformationById Moethod is calling in service layer");
        //    return await _crudApplicationRL.ReadInformationById(request);
        //}

    }
}
