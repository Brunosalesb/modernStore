using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Commands.Results
{
    class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult()
        {

        }
        public RegisterOrderCommandResult(string number)
        {
            Number = number;
        }
        public string Number { get; set; }
    }
}
