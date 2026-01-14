using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ParkBuddy.Application.Handlers.QueryHandlers;
using ParkBuddy.Application.Implemetations;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Domain.Entities;
using ParkBuddy.Infrastructure.Data;
using ParkBuddy.Infrastructure.Identity;
using ParkBuddy.Infrastructure.Repositories;
using ParkBuddy.Infrastructure.Services;
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
builder.Services.AddScoped<IAuthMediatorService, AuthMediatorService>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// DB Context and Repositories
builder.Services.AddDbContext<ParkBuddyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// JWT configuration
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
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
builder.Services.AddCors();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ParkBuddyContext>();
    db.Database.Migrate(); // This applies any pending migrations and creates the database if it doesn't exist
}
await IdentitySeeder.SeedRoles(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));

app.UseHttpsRedirection();
app.MapControllers();

app.Run();