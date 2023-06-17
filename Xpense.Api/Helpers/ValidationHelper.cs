using System.Text.RegularExpressions;

namespace Xpense.Api.Helpers;

public class ValidationHelper
{
    public static bool ValidateCategory(string name)
    {
        return Regex.IsMatch(name, "^[a-zA-Z0-9]*$");
    }
}