namespace System_for_sending_e_mail.Emails.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FromEmail { get; set; }

        public int EmailId { get; set; }
        public Email Email { get; set; }
    }
}
