using System;
using FluentValidator;

namespace MarshalStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }

}