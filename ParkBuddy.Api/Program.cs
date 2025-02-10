using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Mappings;
using ParkBuddy.Application.Validation;
using ParkBuddy.Infrastructure.Data;
using ParkBuddy.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IParkingRepository, ParkingRepository>();
builder.Services.AddScoped<IParkingMapper, ParkingMapper>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterParkingDtoValidator>();

builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ParkBuddyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();