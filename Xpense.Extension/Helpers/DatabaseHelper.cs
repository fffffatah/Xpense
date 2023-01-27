namespace Xpense.Extension.Helpers
{
    public class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            return Environment.GetEnvironmentVariable("SQL_SERVER_CONNECTION");
        }
    }
}
