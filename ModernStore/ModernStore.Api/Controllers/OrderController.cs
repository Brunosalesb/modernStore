using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transactions;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly OrderHandler _handler;

        public OrderController(IUnitOfWork unitOfWork,OrderHandler handler) : base(unitOfWork)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterOrderCommand cmd)
        {
            var result = _handler.Handle(cmd);
            return await Response(result, _handler.Notifications);
        }
    }
}
