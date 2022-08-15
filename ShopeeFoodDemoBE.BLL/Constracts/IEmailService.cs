using ShopeeFoodDemoBE.BLL.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IEmailService
    {
        void SendEmail(EmailRequest request);
    }
}
