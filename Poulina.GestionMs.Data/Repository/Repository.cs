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
        //    private DbSet<T> table = null;
        //    private readonly Context _context;

        //    public Repository(Context context)
        //    {

        //        _context = context;
        //        table = _context.Set<T>();
        //    }

        //    public T GetById(Guid id)
        //    {
        //        IQueryable<T> query = _context.Set<T>();
        //        return table.Find(id);
        //        //return query.Where<T.Equals.>
        //        //return _context.Set<T>().FirstOrDefault();
        //    }

        //    public string Add(T entity)
        //    {
        //        try
        //        {
        //            _context.Set<T>().Add(entity);
        //            _context.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);

        //        }
        //        return "Added done";
        //    }

        //    public string Update(T entity)
        //    {
        //        _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        _context.SaveChanges();
        //        return "Update Done";
        //    }

        //    public string Delete(Guid id)
        //    {
        //        T existing = table.Find(id);
        //        table.Remove(existing);

        //        _context.SaveChanges();
        //        return "Delete Done";
        //        //   return "objet supprimé avec succés";
        //    }
        //    public IEnumerable<T> GetAll()
        //    {
        //        return table.ToList();
        //    }


        //}


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
