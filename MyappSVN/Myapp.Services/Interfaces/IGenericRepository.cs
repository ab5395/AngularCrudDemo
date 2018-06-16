using Myapp.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Myapp.Services.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        IQueryable<T> AllIncluding(bool asNoTracking = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetAll(bool asNoTracking = false);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        int Count();
        //T GetSingle(Guid id);
        T GetSingle(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T GetSingleWithoutTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleWithoutTrackingAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
