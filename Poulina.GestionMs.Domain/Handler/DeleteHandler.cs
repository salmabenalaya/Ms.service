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
    public class DeleteHandler<TEntity> : IRequestHandler<DeleteGeneric<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> Repository;
        public DeleteHandler(IRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }
        public Task<TEntity> Handle(DeleteGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Delete(request.Id);
            return Task.FromResult(result);
        }
    }
}

    //    public class DeleteHandler<T> : IRequestHandler<DeleteGeneric<T>, string> where T : class
    //    {
    //        private readonly IRepository<T> repository;
    //        public DeleteHandler(IRepository<T> Repository)
    //        {
    //            repository = Repository;
    //        }
    //        public Task<string> Handle(DeleteGeneric<T> request, CancellationToken cancellationToken)
    //        {

    //            var result = repository.Delete(request.Id);
    //            return Task.FromResult(result);
    //        }


    //    }
    //}
