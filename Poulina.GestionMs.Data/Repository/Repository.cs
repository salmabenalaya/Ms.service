using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Poulina.GestionMs.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Poulina.GestionMs.Data.Repository
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
 

        private Context _context = null;
        private DbSet<TEntity> table = null;


        #region Constructor
        public Repository(Context context)
        {
            _context = context;
            table = _context.Set<TEntity>();
        }
        #endregion

        #region Get Function
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).ToList();

                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).FirstOrDefault();

                else
                    return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        #endregion

        #region Post Function
        public TEntity Add(TEntity Entity)
        {
            table.Add(Entity);
            _context.SaveChanges();
            return Entity;
        }

        #endregion

        #region Update Function
        public TEntity Put(TEntity Entity)
        {
            table.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Entity;
        }

        #endregion

        #region Delete Function
        public TEntity Delete(Guid Id)
        {
            TEntity existing = table.Find(Id);
            table.Remove(existing);
            _context.SaveChanges();
            return existing;

        }
        #endregion
    }
}
