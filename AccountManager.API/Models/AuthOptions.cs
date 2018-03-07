using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AccountManager.API.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "AccountManager";
        public const string AUDIENCE = "http://localhost:5000/"; 
        const string PASS = "IdentityAccountManager2018";  
        public const int LIFETIME = 1; 

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(PASS));
        }
    }
}
