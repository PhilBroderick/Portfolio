using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Exceptions;
using Portfolio.Core.Interfaces.Services;
using Portfolio.Core.ServiceModels;

namespace Portfolio.Controllers
{
    [ApiController]
    [Route("subscribe")]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscribeController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }
        
        [HttpPost]
        public async Task<IActionResult> SubscribeEmail([FromBody]string email)
        {
            try
            {
                await _subscriberService.AddNewSubscriber(new CreateSubscriberRequest(email, true));
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}