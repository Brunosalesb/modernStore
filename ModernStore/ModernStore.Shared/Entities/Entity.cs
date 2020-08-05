using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Shared.Entities
{
    //abstract para nao poder ser instanciada
    public abstract class Entity : Notifiable
    {
        //protected para so quem herda essa classe pode acessar esse ctor
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
