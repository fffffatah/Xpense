using Microsoft.Extensions.Options;

namespace Xpense.Extension.Core.Database
{
    public class SqlServerConfigurationValidation : IValidateOptions<SqlServerConfiguration>
    {
        public ValidateOptionsResult Validate(string name, SqlServerConfiguration options)
        {
            if (string.IsNullOrEmpty(options.ConnectionString))
                return ValidateOptionsResult.Fail($"{nameof(options.ConnectionString)} Configuration parameter for the SQL Server connection string is required");

            return ValidateOptionsResult.Success;
        }
    }
}
