using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Sip.Tiger.Api.Swagger
{
    public class ProducesValidationErrorAttribute : ProducesResponseTypeAttribute
    {
        public ProducesValidationErrorAttribute() : base(typeof(BadRequestSampleModel), (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
