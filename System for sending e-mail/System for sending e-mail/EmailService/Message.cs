using MimeKit;

namespace System_for_sending_e_mail.EmailService
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(List<string> to, string subject, string content)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(string.Empty.ToString(),x.ToString())));
            Subject = subject;
            Content = content;   
        }
    }
}