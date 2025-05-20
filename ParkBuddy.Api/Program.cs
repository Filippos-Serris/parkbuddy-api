using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParkBuddy.Application.Handlers.QueryHandlers;
using ParkBuddy.Application.Implemetations;
using ParkBuddy.Application.Interfaces;
using ParkBuddy.Application.Validation;
using ParkBuddy.Infrastructure.Data;
using ParkBuddy.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblyContaining<RegisterParkingDtoValidator>();
builder.Services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(typeof(GetParkingListHandler).Assembly));

builder.Services.AddScoped<IParkingMediatorService, ParkingMediatorService>();
builder.Services.AddScoped<IParkingRepository, ParkingRepository>();

builder.Services.AddOpenApi();

builder.Services
    .AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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