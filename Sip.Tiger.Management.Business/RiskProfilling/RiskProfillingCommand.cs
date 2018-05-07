using System;
using MediatR;

namespace Sip.Tiger.Management.Business.RiskProfilling
{
   public class RiskProfillingCommand : IRequest<Guid>
    {
        public int RiskAppetiteScore { get; set; }
        public int TimeHorizonScore { get; set; }
    }
}
