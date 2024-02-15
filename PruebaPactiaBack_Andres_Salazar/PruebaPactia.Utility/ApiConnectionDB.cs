using Microsoft.Extensions.Configuration;

namespace PruebaPactia.Utility
{
    public static class ApiConnectionDB
    {
        static ApiConnectionDB()
        {

        }

        public static string ConnectionStringPrueba
        {
            get
            {
                var builder = new ConfigurationBuilder();

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builder.AddJsonFile($"appsettings.{env}.json", optional: true);

                var configuration = builder.Build();
                var connectionString = configuration.GetConnectionString("DBPruebaPactia");
                return connectionString;
            }
        }
    }
}
