using System.Security.Cryptography;
using System.Text;

namespace Quan_ly_may_bay.Base
{
    internal class Common
    {
        public static byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
