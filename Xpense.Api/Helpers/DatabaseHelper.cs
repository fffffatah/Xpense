namespace Xpense.Api.Helpers
{
    public class DatabaseHelper
    {
        /// <summary>
        /// Get Sql Server Connection String from Environemnt Variable or Appsettings
        /// Null is returned if not found
        /// </summary>
        /// <param name="builder">WebApplicationBuilder object</param>
        /// <returns>Sql Server Connection string</returns>
        public static string GetConnectionString(WebApplicationBuilder builder)
        {
            var connectionStringEnv = Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION");

            if (connectionStringEnv != null)
                return connectionStringEnv;

            return builder.Configuration.GetSection("ConnectionStrings:SQL_SERVER_CONNECTION").Value;
        }
    }
}
