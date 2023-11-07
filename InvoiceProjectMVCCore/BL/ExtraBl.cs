using System.Net.Mail;
using System.Net;

namespace InvoiceProjectMVCCore.BL
{
    public class ExtraBl
    {


        public static void Send_Email(string email, string subject, String description)
        {

            var fromAddress = new MailAddress("krantisinhpatil9@gmail.com", "Inventory System");
            var toAddress = new MailAddress(email, email);
            MailMessage message = new MailMessage(fromAddress, toAddress);
            message.Subject = subject;
            message.Body = description;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential networkcred = new NetworkCredential();
            networkcred.UserName = "krantisinhpatil9@gmail.com";
            networkcred.Password = "nzvazmzszpyucmms";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = networkcred;
            smtp.Port = 587;
            smtp.Send(message);
        }

    }
}
