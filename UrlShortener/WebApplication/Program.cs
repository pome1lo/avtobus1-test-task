using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Data.Interfaces;
using WebApplication.Data.Repositories;
using WebApplication.GlobalExceptionHandler;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Services.Interfaces;
using WebApplication.Services.Validators;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IShortLinkRepository, ShortLinkRepository>();
builder.Services.AddScoped<IShortLinkService, ShortLinkService>();
builder.Services.AddScoped<IValidator<ShortLink>, ShortLinkValidator>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseGlobalExceptionHandler();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "The WebApplication is working.");

app.Run();
