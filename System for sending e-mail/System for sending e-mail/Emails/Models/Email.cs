
namespace System_for_sending_e_mail.Emails.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string ToEmail { get; set; }
        public List<Notification> Notifications { get; set; }
    }

}
