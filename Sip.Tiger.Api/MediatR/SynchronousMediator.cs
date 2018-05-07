using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace Sip.Tiger.Api.MediatR
{
    public class SynchronousMediator : Mediator
    {
        public SynchronousMediator(ServiceFactory serviceFactory) : base(serviceFactory)
        {
        }

        protected override async Task PublishCore(IEnumerable<Task> allHandlers)
        {
            foreach (var handler in allHandlers)
            {
                await handler;
            }
        }
    }
}
