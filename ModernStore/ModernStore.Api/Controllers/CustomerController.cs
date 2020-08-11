using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _iuow;
        private readonly CustomerHandler _handler;

        public CustomerController(IUnitOfWork iuow, CustomerHandler handler)
        {
            _iuow = iuow;
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody]RegisterCustomerCommand cmd)
        {
            var result = _handler.Handle(cmd);

            if (_handler.IsValid())
                return Ok(result);

            else
                return BadRequest(_handler.Notifications);
        }


    }
}
