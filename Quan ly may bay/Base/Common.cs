using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms.VisualStyles;
using System.Configuration;

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
        public static string connectionString = ConfigurationManager.ConnectionStrings["QLCBConnectString"].ConnectionString;
    }
}
