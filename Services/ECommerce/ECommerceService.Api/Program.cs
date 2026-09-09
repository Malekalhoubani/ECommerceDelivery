using BuildingBlocks.Common.Exceptions;
using DataAccess.Repositories.GenericRepository;
using DataAccess.UnitOfWork;
using ECommerceService.Application.Services.Products;
using ECommerceService.Infrastructure.Data;
using Logging.Configurations;
using Logging.Correlation;
using Logging.Exceptions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using DataAccess.Contexts;
var builder = WebApplication.CreateBuilder(args);

SerilogConfiguration.CreateLoggerConfiguration(builder.Environment.ApplicationName,builder.Environment.EnvironmentName).CreateLogger();

builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ECommerceConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<BaseDbContext>(sp =>sp.GetRequiredService<ECommerceDbContext>());
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