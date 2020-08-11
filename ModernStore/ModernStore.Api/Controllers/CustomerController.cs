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
        private readonly IUnitOfWork _uow;
        private readonly CustomerHandler _handler;

        public CustomerController(IUnitOfWork uow, CustomerHandler handler)
        {
            _uow = uow;
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] RegisterCustomerCommand cmd)
        {
            var result = _handler.Handle(cmd);

            if (_handler.IsValid())
            {
                _uow.Commit();
                return Ok(result);
            }

            else
                return BadRequest(_handler.Notifications);
        }


    }
}
