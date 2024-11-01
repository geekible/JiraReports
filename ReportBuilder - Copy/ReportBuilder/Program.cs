using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using ReportBuilder.Application;
using ReportBuilder.Components;
using ReportBuilder.Domain;
using ReportBuilder.Domain.Configuration;
using ReportBuilder.Infrastructure;
using ReportBuilder.Infrastructure.DataAccess;
using Serilog;

IConfigurationRoot configBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var infrastructureConfig = configBuilder.GetSection("InfrastructureConfig").Get<InfrastructureConfigDto>();

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConfigDb") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ConfigApplicationDbContext>(opts => opts.UseSqlServer(connectionString));

builder.Host.UseSerilog((ctx, cfg) =>
{
    cfg.ReadFrom.Configuration(configBuilder);
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddDataAccess();
builder.Services.AddDto();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(infrastructureConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
