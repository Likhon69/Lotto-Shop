using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Base
{
    public interface IBaseShopRepository<T> : IDisposable where T : class
    {
        T Save(T entity);
        void Add(T entity);

        void Add(params T[] entities);
        void Add(IEnumerable<T> entities);

        bool Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);

        bool Remove(T entity);
        void Remove(long id);
        void RemoveOrder(Guid id);
        void Remove(params T[] entities);
        void Remove(IEnumerable<T> entities);
        T GetById(long id);
        T GetByOrderId(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool disableTracking = true);
        T SingleOrDefault(Expression<Func<T, bool>> predicate = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
      bool disableTracking = true);

        IQueryable<T> Query(string sql, params object[] parameters);

        bool SaveChanges();
    }
}
