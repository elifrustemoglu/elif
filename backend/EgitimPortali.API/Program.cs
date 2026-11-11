using EgitimPortali.API.DTOs;
using EgitimPortali.API.Middlewares;
using EgitimPortali.API.Services;
using EgitimPortali.Core;
using EgitimPortali.Core.Models;
using EgitimPortali.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using EgitimPortali.API.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.AllowAnyOrigin()   
                  .AllowAnyMethod()   
                  .AllowAnyHeader();  
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEventRepository, EfEventRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
//builder.Services.AddScoped<IContactMessageRepository, ContactMessageRepository>();

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IContactMessageService, ContactMessageService>();

try
{
    var app = builder.Build();

    app.UseCors("AllowFrontend");
    app.UseMiddleware<ExceptionMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
    app.MapGet("/", () => "Egitim Portali Web API Ayakta ve Sorunsuz Calisiyor!");

    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("KRÝTÝK HATA: " + (ex.InnerException?.Message ?? ex.Message));
    throw;
}