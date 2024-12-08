// Program.cs
using Microsoft.EntityFrameworkCore;
using SpaceResearchManagementSystem.Data;
using SpaceResearchManagementSystem.Repositories.Interfaces;
using SpaceResearchManagementSystem.Repositories.Implementations;
using SpaceResearchManagementSystem.Services.Interfaces;
using SpaceResearchManagementSystem.Services.Implementations;
using SpaceResearchManagementSystem.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SpaceResearchManagementSystem.Middleware;
using Serilog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// =========================
// 1. Configure Serilog
// =========================

// Read Serilog configuration from appsettings.json
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

// Replace the default .NET Core logger with Serilog
builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Add JWT Authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer {token}')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
// =========================
// 2. Configure Services
// =========================

// a. Add DbContext with SQL Server
builder.Services.AddDbContext<SpaceResearchContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// b. Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMissionRepository, MissionRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IScientificDataRepository, ScientificDataRepository>();
builder.Services.AddScoped<IProjectPlanRepository, ProjectPlanRepository>();
builder.Services.AddScoped<ISafetyLogRepository, SafetyLogRepository>();
builder.Services.AddScoped<IMissionPerformanceRepository, MissionPerformanceRepository>();
builder.Services.AddScoped<ICostManagementRepository, CostManagementRepository>();
builder.Services.AddScoped<IEnvironmentalDataRepository, EnvironmentalDataRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

// c. Register Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMissionService, MissionService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IScientificDataService, ScientificDataService>();
builder.Services.AddScoped<IProjectPlanService, ProjectPlanService>();
builder.Services.AddScoped<ISafetyLogService, SafetyLogService>();
builder.Services.AddScoped<IMissionPerformanceService, MissionPerformanceService>();
builder.Services.AddScoped<ICostManagementService, CostManagementService>();
builder.Services.AddScoped<IEnvironmentalDataService, EnvironmentalDataService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

// d. Register Helpers
builder.Services.AddSingleton<JWT>();
builder.Services.AddSingleton<PasswordHasher>();

// e. Configure Authentication (JWT)
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("Key"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Set to true in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// f. Add Controllers
builder.Services.AddControllers();

// g. Add Swagger (for API documentation and testing)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// h. Configure CORS (if necessary)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("https://your-angular-app-domain.com") // Replace with your Angular app's URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// i. Register Error Handling Middleware
// **Important:** Do NOT register custom middleware like ErrorHandlerMiddleware as a service.
// It should be added to the middleware pipeline directly.
/// **Remove or comment out the following line if present:**
/// builder.Services.AddTransient<ErrorHandlerMiddleware>();

var app = builder.Build();

// =========================
// 3. Configure Middleware
// =========================

// a. Use Error Handling Middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

// b. Use Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// c. Use HTTPS Redirection
app.UseHttpsRedirection();

// d. Use CORS
app.UseCors("AllowSpecificOrigin");

// e. Use Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// f. Map Controllers
app.MapControllers();

// =========================
// 4. Run the Application
// =========================
app.Run();
