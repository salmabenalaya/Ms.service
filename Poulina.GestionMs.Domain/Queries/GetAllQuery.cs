using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Poulina.GestionMs.Domain.Queries
{
    //public class GetAllQuery<T> : IRequest<IEnumerable<T>> where T : class
    //{
    //    GetListGenericQuery
    //}
    public class GetAllQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : class
    {
        public GetAllQuery(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            Condition = condition;
            Includes = includes;
        }
        public Expression<Func<TEntity, bool>> Condition { get; }
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; }
    }
}
