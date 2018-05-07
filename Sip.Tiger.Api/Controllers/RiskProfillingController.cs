using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sip.Tiger.Management.Business.RiskProfilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sip.Tiger.Api.Controllers
{
    [Route("[controller]")]
    public class RiskProfillingController : Controller
    {
        private readonly IMediator mediator;

        public RiskProfillingController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Route("{riskAppetiteScore}/{timeHorizonScore}/RiskProfillingCalculation")]
        [HttpGet]
        public async Task<IActionResult> RiskProfillingCalculation(RiskProfillingCommand riskProfillingCommand)
        {
            var response = await mediator.Send(riskProfillingCommand);
            return Ok(response);
        }
    }
}
