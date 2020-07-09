using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Commands
{
  public class AddGeneric<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public TEntity Entity { get; }

        public AddGeneric(TEntity entity)
        {

            Entity = entity;
        }
    }
}
