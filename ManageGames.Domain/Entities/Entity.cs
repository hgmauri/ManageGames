using System;

namespace ManageGames.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public void GerarId()
        {
            Id = Guid.NewGuid();
        }
    }
}
