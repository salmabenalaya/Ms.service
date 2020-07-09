using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poulina.GestionMs.Domain.Commands
{
   public class PutGeneric<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public PutGeneric(TEntity entity)
        {

            Entity = entity;
        }
        public TEntity Entity { get; }
    }
}
