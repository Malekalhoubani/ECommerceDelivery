using BuildingBlocks.Common.Exceptions;
using ECommerceService.Infrastructure.Data;
using Logging.Configurations;
using Logging.Correlation;
using Logging.Exceptions;
using Microsoft.EntityFrameworkCore;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

SerilogConfiguration.CreateLoggerConfiguration(builder.Environment.ApplicationName,builder.Environment.EnvironmentName).CreateLogger();

builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ECommerceConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseMiddleware<CorrelationIdMiddleware>();

app.UseMiddleware<ExceptionLoggingMiddleware>();

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();