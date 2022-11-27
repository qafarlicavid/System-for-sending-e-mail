namespace System_for_sending_e_mail.EmailService
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
