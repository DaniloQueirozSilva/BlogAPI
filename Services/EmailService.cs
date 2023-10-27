using System.Net;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;

namespace Blog.Services
{
    public class EmailService
    {

        public void Send(string emailTo, string subject, string body) 
        {
            var message = PrepareteMessage(emailTo, subject, body);

            SendEmailBySmtp(message);


        }


        private MailMessage PrepareteMessage(string emailTo, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(Configuration.Smtp.UserName); //

            mail.To.Add(emailTo);

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;


            return mail;
        }

        private bool SendEmailBySmtp(MailMessage Message)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = Configuration.Smtp.Host;
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.Timeout = 5000;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(Configuration.Smtp.UserName, Configuration.Smtp.Password);
                smtpClient.Send(Message);
                smtpClient.Dispose();

                return true;
            }catch (Exception ex) {

                return false;
            }
        }
        

       

        
    }
}
