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
        public static void SendMailTo(string emailTo, string content)
        {
            var fromAddress = new MailAddress("hackgame.tetsting@gmail.com", "hackgame.tetsting@gmail.com");
            var toAddress = new MailAddress(emailTo, emailTo);
            const string fromPassword = "HackGame123";
            const string subject = "Gửi mã OTP";
            string body = content;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
