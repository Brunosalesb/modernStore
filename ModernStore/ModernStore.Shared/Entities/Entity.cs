using FluentValidator;
using System;

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
