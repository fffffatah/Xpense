using Xpense.Api.Helpers;
using Xpense.Extension.Core;

var builder = WebApplication.CreateBuilder(args);
/* Add configurations, add all from environment variables and optionally from 'appsettings.json' file */
builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile("appsettings.json", optional: true);
// Add services to the container.
builder.Services.AddCoreServices(DatabaseHelper.GetConnectionString(builder));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();