using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Commands
{
   public class DeleteGeneric<TEntity> : IRequest<TEntity> where TEntity : class
    {

        public DeleteGeneric(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
