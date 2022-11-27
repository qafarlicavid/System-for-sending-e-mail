using System_for_sending_e_mail.Emails.Models;

namespace System_for_sending_e_mail.ViewModels
{
    public class AddViewModel
    {
        public string FromEmail { get; set; }
        public Email Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool EmailBulk { get; set; }

    }
}
