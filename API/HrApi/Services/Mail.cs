using HrApi.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace HrApi.Services
{
    public class Mail:IMail
    {
        public async Task SendWelcomeMail(String email)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                MailMessage message = new MailMessage();
                message.From = new MailAddress("hrappemail@gmail.com");
                message.To.Add(email);
                string subject = "HRApp";
                message.Subject = subject;
                message.Body = "Welcome to HRApp!";
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcred = new NetworkCredential();
                ntcred.UserName = "hrappemail@gmail.com";
                ntcred.Password = "nnajspdgjelyhaqi";
                smtp.Credentials = ntcred;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);

            }).Start();
        }
    }
}
