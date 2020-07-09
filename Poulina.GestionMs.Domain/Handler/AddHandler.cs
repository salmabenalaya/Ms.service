using MediatR;
using Poulina.GestionMs.Domain.Commands;
using Poulina.GestionMs.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionMs.Domain.Handler
{
    public class AddHandler<TEntity> : IRequestHandler<AddGeneric<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> Repository;

        public AddHandler(IRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<TEntity> Handle(AddGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Add(request.Entity);
            return Task.FromResult(result);
        }
    }


}

     