using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_Auth_System_Project.DataAccessLayer;
using Simple_Auth_System_Project.Model;
using Microsoft.Extensions.Configuration;
using Simple_Auth_System_Project.ServiceLayer;
using Newtonsoft.Json;

namespace Simple_Auth_System_Project.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthDL _authDL;
        public readonly ICRUDApplicationSL _cRUDApplicationSL;
        public readonly ILogger<AuthController> _logger;
        public AuthController(IAuthDL authDL, ICRUDApplicationSL cRUDApplicationSL, ILogger<AuthController> logger)
        {
            _authDL = authDL;
            _cRUDApplicationSL = cRUDApplicationSL;
            _logger = logger;
        }
        //Controller for SignUp
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            try
            {
                response = await _authDL.SignUp(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        //Controller for SignIn
        
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            try
            {
                response = await _authDL.SignIn(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }


        //Controllers for CRUD Operations
        [HttpPost]
        public async Task<IActionResult> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();
            _logger.LogInformation(message: $"AddInformation API Calling In Controller.. {JsonConvert.SerializeObject(request)}");
            try
            {
                response = await _cRUDApplicationSL.AddInformation(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"AddInformation API Error occur: Message{ex.Message}");
                return BadRequest(new { IsSucccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }
        
        [HttpGet]
        public async Task<IActionResult> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            _logger.LogInformation(message: $"ReadAllInformation API Calling In Controller..");
            try
            {
                response = await _cRUDApplicationSL.ReadAllInformation();
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"AddInformation API Error occur: Message{ex.Message}");
                return BadRequest(new { IsSucccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation });
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            _logger.LogInformation(message: $"UpdateAllInformationById API Calling In Controller.. {JsonConvert.SerializeObject(request)}");
            try
            {
                response = await _cRUDApplicationSL.UpdateAllInformationById(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"UpdateAllInformationById API Error occur: Message{ex.Message}");
                return BadRequest(new { IsSucccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }        
        
        [HttpDelete]
        public async Task<IActionResult> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            _logger.LogInformation(message: $"DeleteInformationById API Calling In Controller.. {JsonConvert.SerializeObject(request)}");
            try
            {
                response = await _cRUDApplicationSL.DeleteInformationById(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"DeleteInformationById API Error occur: Message{ex.Message}");
                return BadRequest(new { IsSucccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }



        //Controllers for Simple CRUD Operations
        [HttpPost]
        public async Task<IActionResult> AddInformation1(AddInformation1Request request)
        {
            AddInformation1Response response = new AddInformation1Response();
            try
            {
                response = await _authDL.AddInformation1(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }       

        [HttpGet("{EmpId}")]
        public async Task<IActionResult> ReadAllInformation1(int EmpId)
        {
            ReadAllInformation1Response response = new ReadAllInformation1Response();
            try
            {
                response = await _authDL.ReadAllInformation1(EmpId);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.readAllInformation1 });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateAllInformationById1(UpdateAllInformationById1Request request)
        {
            UpdateAllInformationById1Response response = new UpdateAllInformationById1Response();
            try
            {
                response = await _authDL.UpdateAllInformationById1(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return BadRequest(new { IsSucccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(response);
        }
        
        [HttpDelete]//Only Sets IsActive=0
        public async Task<IActionResult> DeleteInformationById1(DeleteInformationById1Request request)
        {
            DeleteInformationById1Response response = new DeleteInformationById1Response();
            try
            {
                response = await _authDL.DeleteInformationById1(request);
                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return BadRequest(new { IsSucccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(response);
        }      
        
        [HttpDelete]
        [Route("{EmpId:int}")]
        //Deletes the record
        public async Task<IActionResult> DeleteEmpDetails(DeleteEmpDetailsRequest request, int EmpId)
        {
            {
                DeleteEmpDetailsResponse response = new DeleteEmpDetailsResponse();
                try
                {
                    response = await _authDL.DeleteEmpDetails(request,EmpId);
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = ex.Message;
                }
                return Ok(response);
            }
        }
        
    }
}


