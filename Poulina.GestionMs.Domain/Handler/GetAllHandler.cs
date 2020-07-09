using MediatR;
using Poulina.GestionMs.Domain.Interface;
using Poulina.GestionMs.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Poulina.GestionMs.Domain.Handler
{
    //public class GetAllHandler<T> : IRequestHandler<GetAllQuery<T>, IEnumerable<T>> where T : class
    //{
    //    private readonly IRepository<T> repository;
    //    public GetAllHandler(IRepository<T> Repository)
    //    {
    //        repository = Repository;
    //    }


    //    public Task<IEnumerable<T>> Handle(GetAllQuery<T> request, CancellationToken cancellationToken)
    //    {
    //        var x = repository.GetList();
    //        return Task.FromResult(x);
    //    }
    //}

    public class GetAllHandler<TEntity> : IRequestHandler<GetAllQuery<TEntity>, IEnumerable<TEntity>> where TEntity : class
    {
        private readonly IRepository<TEntity> Repository;
        public GetAllHandler(IRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<IEnumerable<TEntity>> Handle(GetAllQuery<TEntity> request, CancellationToken cancellationToken)
        {

            var result = Repository.GetList(request.Condition, request.Includes);
            return Task.FromResult(result);
        }
    }
}
