using Microsoft.EntityFrameworkCore;
using MinimalAPI.DataDapperLayer;
using MinimalAPI.DataDapperLayer.ConnectionFactory;
using MinimalAPI.DataLayer;

var builder = WebApplication.CreateBuilder(args);

var uriAppSettings = "MySettings.json";
builder.Configuration.AddJsonFile(uriAppSettings, false, true);

// Add services to the container.
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IRepository, RepositoryDapper>();
//Dapper Factory
builder.Services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dapper IDbConnection
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

//Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();


