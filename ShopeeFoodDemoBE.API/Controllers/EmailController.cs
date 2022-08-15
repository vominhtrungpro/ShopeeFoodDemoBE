using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start sending mail");
            try
            {
                _emailService.SendEmail(request);
                timer.Stop();
                _logger.LogInformation("Sending mail succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End sending mail");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }
    }
}
