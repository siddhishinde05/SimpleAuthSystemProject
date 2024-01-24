using Azure.Core;
//using Microsoft.Data.SqlClient;
using Simple_Auth_System_Project.CommonUtility;
using Simple_Auth_System_Project.Model;
using System.Data.Common;
using System.Data.SqlClient;

namespace Simple_Auth_System_Project.DataAccessLayer
{
    public class AuthDL : IAuthDL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _loginDbContext;
        public AuthDL(IConfiguration configuration)
        {
            _configuration = configuration;
            _loginDbContext = new SqlConnection(_configuration[key: "ConnectionStrings:LoginDbContext"]);
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"Select * from UserDetails where Username=@Username and Password=@Password and Role=@Role";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _loginDbContext))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Password", request.Password);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Role", request.Role);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    using (DbDataReader dataReader=await sqlCommand.ExecuteReaderAsync()) 
                    {
                        if(dataReader.HasRows) 
                        {
                            response.Message = "Login successfully";
                        }
                        else
                        {
                            response.IsSuccess= false;
                            response.Message = "Login Unsuccessful";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }
    
        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if(!request.Password.Equals(request.ConfirmPassword))
                {
                    response.IsSuccess = false;
                    response.Message = "Password and Confirm Password not matched";
                    return response;
                }
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"Insert into UserDetails(UserName, Password, Role) Values(@UserName,@Password,@Role)";
                using (SqlCommand sqlCommand = new SqlCommand(SqlQuery, _loginDbContext))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Password", request.Password);
                    sqlCommand.Parameters.AddWithValue(parameterName: "@Role", request.Role);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if(Status == 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<AddInformation1Response> AddInformation1(AddInformation1Request request)
        {
            AddInformation1Response response = new AddInformation1Response();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"INSERT INTO EmpDetails(Name,Age,EmailId,ContactNo,Salary)VALUES(@Name,@Age,@EmailId,@ContactNo,@Salary)";

                using (SqlCommand Sqlcmd = new SqlCommand(SqlQuery, _loginDbContext))
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
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;

        }

        public async Task<DeleteInformationById1Response> DeleteInformationById1(DeleteInformationById1Request request)
        {
            DeleteInformationById1Response response = new DeleteInformationById1Response();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"UPDATE EmpDetails SET IsActive=0 WHERE EmpId=@EmpId;";
                using (SqlCommand Sqlcmd = new SqlCommand(SqlQuery, _loginDbContext))
                {
                    Sqlcmd.CommandType = System.Data.CommandType.Text;
                    Sqlcmd.CommandTimeout = 180;
                    Sqlcmd.Parameters.AddWithValue(parameterName: "@EmpId", request.EmpId);
                    int Status = await Sqlcmd.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query Not Executed";
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<ReadAllInformation1Response> ReadAllInformation1(int EmpId)
        {
            ReadAllInformation1Response response = new ReadAllInformation1Response();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"SELECT * FROM EmpDetails;";
                using (SqlCommand SqlCmd = new SqlCommand(SqlQuery, _loginDbContext))
                {
                    try
                    {
                        SqlCmd.CommandType = System.Data.CommandType.Text;
                        SqlCmd.CommandTimeout = 180;
                        using (SqlDataReader dataReader = await SqlCmd.ExecuteReaderAsync())
                        {
                            if (dataReader.HasRows)
                            {
                                response.readAllInformation1 = new List<GetReadAllInformation1>();
                                while (await dataReader.ReadAsync())
                                {
                                    GetReadAllInformation1 getData = new GetReadAllInformation1();
                                    getData.EmpId = dataReader[name: "EmpId"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "EmpId"]) : 0;

                                    getData.Name = dataReader[name: "Name"] != DBNull.Value ? Convert.ToString(dataReader[name: "Name"]) : string.Empty;
                                    
                                    getData.Age = dataReader[name: "Age"] != DBNull.Value ? Convert.ToString(dataReader[name: "Age"]) : string.Empty;

                                    getData.EmailId = dataReader[name: "EmailId"] != DBNull.Value ? Convert.ToString(dataReader[name: "EmailId"]) : string.Empty;

                                    getData.ContactNo = dataReader[name: "ContactNo"] != DBNull.Value ? Convert.ToString(dataReader[name: "ContactNo"]) : string.Empty;

                                    getData.Salary = dataReader[name: "Salary"] != DBNull.Value ? Convert.ToInt32(dataReader[name: "Salary"]) : 0;

                                    getData.IsActive = dataReader[name: "IsActive"] != DBNull.Value ? Convert.ToString(dataReader[name: "IsActive"]) : string.Empty;

                                    response.readAllInformation1.Add(getData);
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
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<UpdateAllInformationById1Response> UpdateAllInformationById1(UpdateAllInformationById1Request request)
        {
            UpdateAllInformationById1Response response = new UpdateAllInformationById1Response();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"UPDATE EmpDetails SET Name=@Name, Age=@Age, EmailId=@EmailId, ContactNo=@ContactNo, Salary=@Salary WHERE EmpId=@EmpId;";

                using (SqlCommand Sqlcmd = new SqlCommand(SqlQuery, _loginDbContext))
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
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

        public async Task<DeleteEmpDetailsResponse> DeleteEmpDetails(DeleteEmpDetailsRequest request,int EmpId)
        {

            DeleteEmpDetailsResponse response = new DeleteEmpDetailsResponse();
            response.IsSuccess = true;
            response.Message = "Sucessful";
            try
            {
                if (_loginDbContext.State != System.Data.ConnectionState.Open)
                {
                    await _loginDbContext.OpenAsync();
                }
                string SqlQuery = @"Delete from EmpDetails where EmpId=@EmpId";
                using (SqlCommand sqlcommand = new SqlCommand(SqlQuery, _loginDbContext))
                {
                    sqlcommand.CommandType = System.Data.CommandType.Text;
                    sqlcommand.CommandTimeout = 180;
                    sqlcommand.Parameters.AddWithValue("@EmpId",request.EmpId);
                    int Status = await sqlcommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _loginDbContext.CloseAsync();
                await _loginDbContext.DisposeAsync();
            }
            return response;
        }

    }
}

