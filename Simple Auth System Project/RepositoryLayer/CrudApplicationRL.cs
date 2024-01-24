using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Simple_Auth_System_Project.CommonUtility;
using Simple_Auth_System_Project.Model;
using Simple_Auth_System_Project.ServiceLayer;
using System.Data.SqlClient;
using static Simple_Auth_System_Project.Model.ReadInformationById;


namespace Simple_Auth_System_Project.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _loginDbContext;
        public readonly ILogger<CrudApplicationRL> _logger;

        public CrudApplicationRL(IConfiguration configuration, ILogger<CrudApplicationRL> logger)
        {
            _configuration = configuration;
            _loginDbContext = new SqlConnection(_configuration[key: "ConnectionStrings:LoginDbContext"]);
            _logger = logger;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            _logger.LogInformation(message: "AddInformation Method calling in repository layer");
            AddInformationResponse response = new AddInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                using (SqlCommand Sqlcmd = new SqlCommand(SqlQueries.AddInformation, _loginDbContext))
                {
                    Sqlcmd.CommandType = System.Data.CommandType.Text;
                    Sqlcmd.CommandTimeout = 180;
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@Name", request.Name);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@EmailId", request.EmailId);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@ContactNo", request.ContactNo);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@Salary", request.Salary);
                    int Status = await Sqlcmd.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError(message: "Error Occur : Query Not Executed");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"Error Occur At AddInformation Repository Layer{ex.Message}");
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                using (SqlCommand SqlCmd = new SqlCommand(SqlQueries.ReadAllInformation, _loginDbContext))
                {
                    try
                    {
                        SqlCmd.CommandType = System.Data.CommandType.Text;
                        SqlCmd.CommandTimeout = 180;
                        using (SqlDataReader dataReader = await SqlCmd.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.readAllInformation = new List<GetReadAllInformation>();
                                while (await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation getData = new GetReadAllInformation();
                                    getData.EmpId = dataReader[name: "EmpId"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "EmpId"]) : 0;

                                    getData.Name = dataReader[name: "Name"] != DBNull.Value ? Convert.ToString(dataReader[name: "Name"]) : string.Empty;

                                    getData.Age = dataReader[name: "Age"] != DBNull.Value ? Convert.ToString(dataReader[name: "Age"]) : string.Empty;

                                    getData.EmailId = dataReader[name: "EmailId"] != DBNull.Value ? Convert.ToString(dataReader[name: "EmailId"]) : string.Empty;

                                    getData.ContactNo = dataReader[name: "ContactNo"] != DBNull.Value ? Convert.ToString(dataReader[name: "ContactNo"]) : string.Empty;

                                    getData.Salary = dataReader[name: "Salary"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "Salary"]) : 0;

                                    getData.IsActive = dataReader[name: "IsActive"] != DBNull.Value ? Convert.ToString(dataReader[name: "IsActive"]) : string.Empty;

                                    response.readAllInformation.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found / Database Empty";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError(message: "GetAllInformation Error Occur:Message:" + ex.Message);
                    }
                    finally
                    {
                        await _loginDbContext.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: "GetAllInformation Error Occur:Message:" + ex.Message);
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }


        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            _logger.LogInformation(message: "UpdateAllInformationById Method calling in repository layer");
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                using (SqlCommand Sqlcmd = new SqlCommand(SqlQueries.UpdateAllInformationById, _loginDbContext))
                {
                    Sqlcmd.CommandType = System.Data.CommandType.Text;
                    Sqlcmd.CommandTimeout = 180;
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@EmpId", request.EmpId);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@Name", request.Name);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@EmailId", request.EmailId);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@ContactNo", request.ContactNo);
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@Salary", request.Salary);
                    int Status = await Sqlcmd.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError(message: "Error Occur : Query Not Executed");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"Error Occur At UpdateAllInformationById Repository Layer{ex.Message}");
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            _logger.LogInformation(message: "DeleteInformationById Method calling in repository layer");
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                using (SqlCommand Sqlcmd = new SqlCommand(SqlQueries.DeleteInformationById, _loginDbContext))
                {
                    Sqlcmd.CommandType = System.Data.CommandType.Text;
                    Sqlcmd.CommandTimeout = 180;
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@EmpId", request.EmpId);
                    int Status = await Sqlcmd.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        _logger.LogError(message: "Error Occur : Query Not Executed");
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: $"Error Occur At DeleteInformationById Repository Layer{ex.Message}");
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<GetDeleteAllInformationResponse> GetDeleteAllInformation()
        {
            GetDeleteAllInformationResponse response = new GetDeleteAllInformationResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                using (SqlCommand SqlCmd = new SqlCommand(SqlQueries.GetDeleteAllInformation, _loginDbContext))
                {
                    try
                    {
                        SqlCmd.CommandType = System.Data.CommandType.Text;
                        SqlCmd.CommandTimeout = 180;
                        using (SqlDataReader dataReader = await SqlCmd.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.getDeleteAllInformation = new List<GetDeleteAllInformation>();
                                while (await dataReader.ReadAsync())
                                {
                                    GetDeleteAllInformation getData = new GetDeleteAllInformation();
                                    getData.EmpId = dataReader[name: "EmpId"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "EmpId"]) : 0;

                                    getData.Name = dataReader[name: "Name"] != DBNull.Value ? Convert.ToString(dataReader[name: "Name"]) : string.Empty;

                                    getData.Age = dataReader[name: "Age"] != DBNull.Value ? Convert.ToString(dataReader[name: "Age"]) : string.Empty;

                                    getData.EmailId = dataReader[name: "EmailId"] != DBNull.Value ? Convert.ToString(dataReader[name: "EmailId"]) : string.Empty;

                                    getData.ContactNo = dataReader[name: "ContactNo"] != DBNull.Value ? Convert.ToString(dataReader[name: "ContactNo"]) : string.Empty;

                                    getData.Salary = dataReader[name: "Salary"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "Salary"]) : 0;

                                    //getData.IsActive = dataReader[name: "IsActive"] != DBNull.Value ? Convert.ToString(dataReader[name: "IsActive"]) : string.Empty;

                                    response.getDeleteAllInformation.Add(getData);
                                }
                            }
                            else
                            {
                                response.IsSuccess = true;
                                response.Message = "Record Not Found";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccess = false;
                        response.Message = ex.Message;
                        _logger.LogError(message: "getDeleteAllInformation Error Occur:Message:" + ex.Message);
                    }
                    finally
                    {
                        await _loginDbContext.DisposeAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(message: "getDeleteAllInformation Error Occur:Message:" + ex.Message);
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        //public async Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request)
        //{
        //    _logger.LogInformation("ReadInformationById Repository Layer Calling");
        //    ReadInformationByIdResponse response = new ReadInformationByIdResponse();
        //    response.IsSuccess = true;
        //    response.Message = "Successful";
        //    try
        //    {
        //        if(_loginDbContext.State!=System.Data.ConnectionState.Open)
        //        {
        //            await _loginDbContext.OpenAsync();
        //        }
            
        //        using(SqlCommand sqlCommand = new SqlCommand(SqlQueries.ReadInformationById, _loginDbContext))
        //        {
        //            sqlCommand.CommandType= System.Data.CommandType.Text;
        //            sqlCommand.CommandTimeout = 180;
        //            sqlCommand.Parameters.AddWithValue("@EmpId", request.EmpId);

        //        }
            
            
            
            
        //    }









        //    throw new NotImplementedException();
        //}


    }
}
