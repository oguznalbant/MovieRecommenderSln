namespace MR.Api.Helper
{
    public interface IEmailSender
    {
        void SendEmail(string email, string subject, string htmlMessage);
    }
}
