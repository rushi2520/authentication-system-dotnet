using System.Net;
using System.Net.Mail;

namespace PracticeMVC_DB_Identitty.Helper
{
    public class EmailSender
    {
        public bool Send(string to, string subject, string message)
        {
            MailMessage msg = new MailMessage();
            SmtpClient client = new SmtpClient();

            //Adding infromation to mainmessage object
            msg.From = new MailAddress("thefourmen365@gmail.com");
            msg.To.Add(to);
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = true;

            //adding SMTP Object information 
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("thefourmen365@gmail.com", "crsi lsuq bhxq teby");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;


            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
