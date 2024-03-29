﻿using Microsoft.AspNetCore.Mvc;
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
    public class CustomerController : BaseController
    {
        private readonly CustomerHandler _handler;

        public CustomerController(IUnitOfWork unitOfWork, CustomerHandler handler) : base(unitOfWork)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterCustomerCommand cmd)
        {
            var result = _handler.Handle(cmd);
            return await Response(result, _handler.Notifications);
        }


    }
}
