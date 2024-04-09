using System.Reflection;
using Application.Core.Managers.EventManager;
using Application.Core.Managers.EventManager.Interfaces;
using Core.Configuration;
using Core.Services.Team.Commands.CreateTeam;
using Domain.Entities.User;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories.BusinessRepository.Employee;
using Infrastructure.Repositories.BusinessRepository.Employee.Interface;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary;
using Infrastructure.Repositories.BusinessRepository.EmployeeSalary.Interface;
using Infrastructure.Repositories.BusinessRepository.Event;
using Infrastructure.Repositories.BusinessRepository.Event.Interface;
using Infrastructure.Repositories.BusinessRepository.Institution;
using Infrastructure.Repositories.BusinessRepository.Institution.Interface;
using Infrastructure.Repositories.BusinessRepository.Spectacle;
using Infrastructure.Repositories.BusinessRepository.Spectacle.Interface;
using Infrastructure.Repositories.BusinessRepository.Team;
using Infrastructure.Repositories.BusinessRepository.Team.Interface;
using Infrastructure.Repositories.BusinessRepository.TeamMember;
using Infrastructure.Repositories.BusinessRepository.TeamMember.Interface;
using Infrastructure.Repositories.GenericRepository.AuditGenericRepository;
using Infrastructure.Repositories.GenericRepository.BaseGenericRepository;
using Infrastructure.Repositories.GenericRepository.FullAuditGenericRepository;
using Infrastructure.Repositories.UnitOfWorkRepository;
using Infrastructure.Repositories.UnitOfWorkRepository.ApplicationUnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(CreateTeamHandler)));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateTeamHandler)) ??
                                                                    throw new InvalidOperationException(
                                                                        "Can't find mediator assembly")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton(cfg => cfg.GetRequiredService<IOptions<AuthOptions>>().Value);

builder.Services.AddIdentity<UserEntity, IdentityRole<string>>(
        options =>
        {
            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ -|%'";
        })
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = true;
});

var section = builder.Configuration.GetSection("AuthOptions");
builder.Services.Configure<AuthOptions>(section);
var authOptions = section.Get<AuthOptions>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = authOptions?.Issuer,

        ValidateAudience = true,
        ValidAudience = authOptions?.Audience,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = authOptions?.GetSymmetricSecurityKey(),
    };
});

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Teatru project 1",
        Description = "InternalProject"
    });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer tokenText\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddTransient(typeof(IBaseGenericRepository<>), typeof(BaseGenericRepository<>));
builder.Services.AddTransient(typeof(IAuditGenericRepository<>), typeof(AuditGenericRepository<>));
builder.Services.AddTransient(typeof(IFullAuditGenericRepository<>), typeof(FullAuditGenericRepository<>));


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IApplicationUnitOfWork, ApplicationUnitOfWork>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IInstitutionRepository, InstitutionRepository>();
builder.Services.AddTransient<ISpectacleRepository, CacheSpectacleRepository>();
builder.Services.AddTransient<SpectacleRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<ITeamMemberRepository, TeamMemberRepository>();
builder.Services.AddScoped<IEventManagementManager, EventManagementManager>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpMetrics();
app.UseHttpMetrics();
app.MapControllers();

app.Run();