
using server.Models;

namespace server.Config
{
    public class InitConfig
    {
        public string? db;

        private readonly string? env;
        private readonly IConfigurationBuilder configbuilder;
        private readonly IConfigurationRoot config;
        
        public InitConfig(WebApplicationBuilder builder)
        {
            // Check ENV Name
            env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var strjson = env == "Development" ? $"appsettings.{env}.json" : "appsettings.json";

            // Get config in appsetting json

            configbuilder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(strjson)
            .AddEnvironmentVariables();

            config = configbuilder.Build();

            var connstr = config.GetConnectionString("MyDatabase");

            builder.Services.AddDbContext<PapayaDbContext>(options =>
            {
                options.UseMySql(connstr, ServerVersion.AutoDetect(connstr));
            });
        }
    }

}