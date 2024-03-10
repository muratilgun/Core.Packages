using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Security.Encryption;
public static class SecurityKeyHelper
{
    public static SecurityKey GetSecurityKey(string securityKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

}
