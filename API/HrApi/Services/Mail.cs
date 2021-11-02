using HrApi.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;

namespace HrApi.Services
{
    public class Mail:IMail
    {
        public async Task SendWelcomeMail(String email,byte[] url,String firstname,String lastname)
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
                message.Body = message.Body + Environment.NewLine + firstname;
                message.Body = message.Body + Environment.NewLine + lastname;
                message.Body = message.Body + Environment.NewLine;
               

                var imageStream = GetImageStream(url);
                var imageResource = new LinkedResource(imageStream, "image/png") { ContentId = "added-image-id" };
                var alternateView = AlternateView.CreateAlternateViewFromString(message.Body, message.BodyEncoding, MediaTypeNames.Text.Html);

                alternateView.LinkedResources.Add(imageResource);
                message.AlternateViews.Add(alternateView);
                


                smtp.Credentials = ntcred;
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(message);

            }).Start();
        }
        private static Stream GetImageStream(byte[] imageBytes)
        {
            var memoryStream = new MemoryStream(imageBytes);
            return memoryStream;
        }
    }
}
