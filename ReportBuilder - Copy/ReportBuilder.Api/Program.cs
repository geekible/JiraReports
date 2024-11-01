using Microsoft.EntityFrameworkCore;
using ReportBuilder.Application;
using ReportBuilder.Domain;
using ReportBuilder.Domain.Configuration;
using ReportBuilder.Infrastructure;
using ReportBuilder.Infrastructure.DataAccess;

const string Unrestricted = "Unrestricted";

IConfigurationRoot configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var infrastructureConfig = configBuilder.GetSection("InfrastructureConfig").Get<InfrastructureConfigDto>();

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConfigDb") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ConfigApplicationDbContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: Unrestricted,
        builder => builder
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod());
});

builder.Services.AddDataAccess();
builder.Services.AddDto();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(infrastructureConfig);

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
app.UseCors(Unrestricted);
app.Run();
