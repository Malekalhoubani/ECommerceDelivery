using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging.Configurations
{
     public static class SerilogConfiguration
    {
        public static LoggerConfiguration CreateLoggerConfiguration(string applicationName, string environmentName)
        {
            return new LoggerConfiguration().MinimumLevel.Information().Enrich.FromLogContext().Enrich.WithProperty("ApplicationName", applicationName).Enrich.WithProperty("EnvironmentName", environmentName).WriteTo.Console().WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);

        }

     }
}
