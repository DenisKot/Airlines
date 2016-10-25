namespace _03.Services.Services
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;

    public class SmtpService
    {
        public void Send(string html, string email)
        {
            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    mail.From = new MailAddress("d.kotenko@eleganceukraine.com");
            //    mail.To.Add(new MailAddress(email));
            //    mail.Subject = "Авіаквиток";
            //    mail.Body = message;
            //    if (!string.IsNullOrEmpty(attachFile))
            //        mail.Attachments.Add(new Attachment(attachFile));
            //    SmtpClient client = new SmtpClient();
            //    client.Host = smtpServer;
            //    client.Port = 587;
            //    client.EnableSsl = true;
            //    client.Credentials = new NetworkCredential(from.Split('@')[0], password);
            //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //    client.Send(mail);
            //    mail.Dispose();
            //}
            //catch (Exception e)
            //{
            //    throw new Exception("Mail.Send: " + e.Message);
            //}

            try
            {
                MailMessage mail = new MailMessage("skytechstidios@gmail.com", email);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.google.com";
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("skytechstidios@gmail.com", "2elojwp-perl");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                mail.Subject = "Авіаквиток";
                mail.IsBodyHtml = true;
                mail.Body = html;
                client.Send(mail);
            } catch (Exception)
            {
                //Console.WriteLine(EX_NAME);
            }

            ////Авторизация на SMTP сервере
            //SmtpClient Smtp = new SmtpClient("smtp.mail.ru", 25);
            //Smtp.Credentials = new NetworkCredential("login", "pass");
            ////Smtp.EnableSsl = false;

            //////Формирование письма
            ////MailMessage Message = new MailMessage();
            ////Message.From = new MailAddress("from@mail.ru");
            ////Message.To.Add(new MailAddress("to@mail.ru"));
            ////Message.Subject = "Заголовок";
            ////Message.Body = "Сообщение";

            //////Прикрепляем файл
            ////string file = "C:\file.zip";
            ////Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);

            ////// Добавляем информацию для файла
            ////ContentDisposition disposition = attach.ContentDisposition;
            ////disposition.CreationDate = System.IO.File.GetCreationTime(file);
            ////disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            ////disposition.ReadDate = System.IO.File.GetLastAccessTime(file);

            ////Message.Attachments.Add(attach);

            ////Smtp.Send(Message);//отправка
        }
    }
}
