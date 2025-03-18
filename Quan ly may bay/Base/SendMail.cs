using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_may_bay
{
    internal class SendMail
    {
        public static string taikhoan = "hackgame.testing@gmail.com";
        public static string matkhau = ".........";
        public static bool SendMailTo(string emailto, string content)
        {
            var formAddress = new MailAddress(taikhoan, "HKPLANE");
            var toAddress = new MailAddress(emailto, emailto);
            string formPassword = matkhau;
            string subject = "Thong bao xác thực mã OTP";
            string body = content;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(formAddress.Address, formPassword)
            };

            try
            {
                using (var message = new MailMessage(formAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
