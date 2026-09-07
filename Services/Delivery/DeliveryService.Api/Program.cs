using DeliveryService.Infrastructure.Data;
using Logging.Configurations;
using Logging.Correlation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Logging.Exceptions;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(SerilogConfiguration.CreateLoggerConfiguration(builder.Environment.ApplicationName, builder.Environment.EnvironmentName).CreateLogger());
builder.Services.AddDbContext<DeliveryDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DeliveryConnection")));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

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