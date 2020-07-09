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
    //    public class PutHandler<T> : IRequestHandler<PutGeneric<T>, string> where T : class
    //    {
    //        private readonly IRepository<T> repository;
    //        public PutHandler(IRepository<T> Repository)
    //        {
    //            repository = Repository;
    //        }



    //        public Task<string> Handle(PutGeneric<T> request, CancellationToken cancellationToken)
    //        {
    //            var result = repository.Put(request.Obj);
    //            return Task.FromResult(result);
    //        }
    //    }
    //}
    public class PutHandler<TEntity> : IRequestHandler<PutGeneric<TEntity>, TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> Repository;
        public PutHandler(IRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }
        public Task<TEntity> Handle(PutGeneric<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Put(request.Entity);
            return Task.FromResult(result);
        }
    }
}

