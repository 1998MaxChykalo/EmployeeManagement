using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        // Task<IEnumerable<T>> GetAllAsync();
        T GetById(object id);
        // Task<T> GetByIdAsync(object id);
        void Create(T item); 
        // void CreateAsync(T item); 
        void Update(T item); 
        // void UpdateAsync(T item); 
        void Delete(object id);
        // void DeleteAsync(object id);
        // void DeleteRange(object[] ids);
    }

    // public interface IRepository<TM, TE>
    //  where TM : class, new()
    //  where TE : class, new() 
    // {
    //     IEnumerable<TM> AllIncluding(params Expression<Func<TE, object>>[] includeProperties);
    //     Task<IEnumerable<TM>> AllIncludingAsync(params Expression<Func<TE, object>>[] includeProperties);
    //     IEnumerable<TM> GetAll();
    //     Task<IEnumerable<TM>> GetAllAsync();
    //     TM GetSingle(object id);
    //     TM GetSingle(Expression<Func<TE, bool>> predicate);
    //     // TE GetSingle(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includeProperties);
    //     Task<TM> GetSingleAsync(object id);
    //     IEnumerable<TM> FindBy(Expression<Func<TE, bool>> predicate);
    //     Task<IEnumerable<TM>> FindByAsync(Expression<Func<TE, bool>> predicate);
    //     void Add(TM entity);
    //     void Delete(TM entity);
    //     void Update(TM entity);
    //     void Commit();
    // }
}