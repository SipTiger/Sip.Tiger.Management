using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
namespace Sip.Tiger.Management.Business.RiskProfilling
{
    public class RiskProfillingHandler : IRequestHandler<RiskProfillingCommand, Guid>
    {
        public async Task<Guid> Handle(RiskProfillingCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }
}
