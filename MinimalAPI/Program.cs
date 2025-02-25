var builder = WebApplication.CreateBuilder(args);

var uriAppSettings = "MySettings.json";
builder.Configuration.AddJsonFile(uriAppSettings, false, true);

// Add services to the container.
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IUsuariosBusiness, UsuariosBusiness>();
builder.Services.AddScoped<IRepositoryDapper, RepositoryDapper>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddAutoMapper(typeof(Program));
//Dapper Factory
builder.Services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")));

//Dapper IDbConnection
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

//Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
//app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var routeGroupBuilder = app.MapGroup("cursonet");
routeGroupBuilder.MapGroup("/usuarios").MapUsuarios();
app.MapEndpoints();

app.Run();


