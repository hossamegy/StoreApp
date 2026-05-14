using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using StoreApp.API.Config;
using StoreApp.Infrastructure;
using StoreApp.Infrastructure.Data;
using StoreApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddDbContextRegistration();
builder.AddMapperConfig();
builder.AddAuthConfig();
builder.JsonResponseCamelCaseConfig();

builder.AddInfrastructureRegistration();
builder.AddServicesRegistration();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapGet("/", () => "StoreApp API running");

app.MapControllers();

app.Run();