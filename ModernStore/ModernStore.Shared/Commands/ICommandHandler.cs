﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
