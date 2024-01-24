using Simple_Auth_System_Project.DataAccessLayer;
using Simple_Auth_System_Project.RepositoryLayer;
using Simple_Auth_System_Project.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICRUDApplicationSL, CrudApplicationSL>();
builder.Services.AddScoped<ICrudApplicationRL, CrudApplicationRL>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthDL, AuthDL>();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
//    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseSwagger();

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 