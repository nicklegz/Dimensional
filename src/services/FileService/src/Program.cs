using file_service.Config;
using file_service.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DbSettings>(
    builder.Configuration.GetSection("FileServiceDb"));

JwtConfig.ConfigureJwtAuthentication(builder.Services, builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();