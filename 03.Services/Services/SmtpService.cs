namespace _03.Services.Services
{
    using System.Net.Mail;

    public class SmtpService
    {
        public void Send(string html, string email)
        {
            MailMessage mail = new MailMessage("the_matrix@ukr.net", email);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = "Авіаквиток";
            mail.IsBodyHtml = true;
            mail.Body = html;
            client.Send(mail);
        }
    }
}
