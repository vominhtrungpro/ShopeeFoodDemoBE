using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IEmailService
    {
        void SendEmail(EmailRequest request);
    }
}
