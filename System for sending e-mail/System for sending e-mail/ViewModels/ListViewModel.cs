using System_for_sending_e_mail.Emails.Models;

namespace System_for_sending_e_mail.ViewModels
{
    public class ListViewModel
    {
        public string Title { get; set; }
        public string FromEmail { get; set; }
        public string TargetEmail { get; set; }  

        public ListViewModel( string title,  string fromEmail, string targetEmail)
        {
            Title = title;
            FromEmail = fromEmail;
            TargetEmail = targetEmail;
        }
    }
}
