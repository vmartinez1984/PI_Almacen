using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace HelpDesk.Notifications
{
    public class EmailNotification
    {
        public static void Send(string email)
        {
            const string emailSource = "148318@udlondres.com";
            const string emailPasword = "macross#2012";
            const string Host = "smtp.gmail.com";
            MailMessage mailMessage;
            SmtpClient smtpClient;
            
            mailMessage = new MailMessage
            (
                emailSource,
                email,
                "Notificación",
                "Cuerpo del la notificación."
            );
            mailMessage.IsBodyHtml = true;
            smtpClient = new SmtpClient(Host);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = Host;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(emailSource, emailPasword);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();
        }
    }
}
