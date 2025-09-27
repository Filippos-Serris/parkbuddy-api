using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Handlers.QueryHandlers;
using ParkBuddy.Application.Implemetations;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;
using ParkBuddy.Infrastructure.Identity;
using ParkBuddy.Infrastructure.Repositories;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddValidatorsFromAssemblyContaining<RegisterParkingDtoValidator>();
builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(typeof(GetParkingListHandler).Assembly));
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ParkBuddyContext>()
    .AddDefaultTokenProviders();

// Application services
builder.Services.AddScoped<IUserMediatorService, UserMediatorService>();
builder.Services.AddScoped<IParkingMediatorService, ParkingMediatorService>();

// DB Context and Repositories
builder.Services.AddDbContext<ParkBuddyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();

// JWT configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["SKey"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key)
    };
});
builder.Services.AddAuthorization();

builder.Services
    .AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await IdentitySeeder.SeedRoles(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();