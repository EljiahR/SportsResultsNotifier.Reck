using System.Net.Mail;
using System.Net;

namespace SportsResultsNotifier;

public class Email
{
    private readonly string _email;
    private readonly string _password;
    private readonly string _recieverEmail;
    private readonly string smtpAddress = "smtp.gmail.com";
    private readonly int portNumber = 587;
    private readonly bool enableSSL = true;
    public Email(string email, string password, string recieverEmail)
    {
        _email = email;
        _password = password;
        _recieverEmail = recieverEmail;
    }
    public void SendEmail(string subject, string body)
    {
        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(_email);
            mail.To.Add(_recieverEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(_email, _password);
                smtp.EnableSsl = enableSSL;
                smtp.Send(mail);
            }
        }
    }
}
