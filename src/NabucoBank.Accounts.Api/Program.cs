using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using NabucoBank.Accounts.Application.Interfaces;
using NabucoBank.Accounts.Application.Services;
using NabucoBank.Accounts.CrossCutting.AutoMapper;
using NabucoBank.Accounts.CrossCutting.Configuration;
using NabucoBank.Accounts.Domain.Interfaces;
using NabucoBank.Accounts.Domain.Interfaces.Repositories;
using NabucoBank.Accounts.Domain.Services;
using NabucoBank.Accounts.Infrastructure.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

const string _pathBase = "/accounts-api";
const string _apiName = "NabucoBank - Accounts Api";

builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
DbMapping.InitializeMapping();

builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IBankRepository, BankRepository>();

builder.Services.AddTransient<IDbConnection>((sql) => new MySqlConnection(builder.Configuration.GetConnectionString("NabucoBank")));

// Add services app
builder.Services.AddScoped<IAccountServiceApp, AccountServiceApp>();
builder.Services.AddScoped<ICustomerServiceApp, CustomerServiceApp>();
builder.Services.AddScoped<IAddressServiceApp, AddressServiceApp>();
builder.Services.AddScoped<IBankServiceApp, BankServiceApp>();

// Add services domain
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IBankService, BankService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = _apiName,
        Version = "v1.0.0"
    });

    c.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();
app.UsePathBase(new PathString(_pathBase));
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"{_pathBase}/swagger/v1/swagger.json", _apiName);
    c.RoutePrefix = string.Empty;
});
app.MapControllers();
app.Run();
