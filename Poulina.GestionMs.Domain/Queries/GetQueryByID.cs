using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Poulina.GestionMs.Domain.Queries
{
    //public class GetQueryByID<T> : IRequest<T> where T : class
    //{
    //    public GetQueryByID(Guid id)
    //    {
    //        Id = id;
    //    }
    //    public Guid Id { get; set; }
    //}

    public class GetQueryByID<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public GetQueryByID(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            Condition = condition;
            Includes = includes;
        }
        public Expression<Func<TEntity, bool>> Condition { get; }
        public Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Includes { get; }
    }
}

