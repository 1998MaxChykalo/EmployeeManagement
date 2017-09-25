// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using AutoMapper;
// using EmployeeManagement.Infrastructure.Repositories;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;

// namespace EmployeeManagement.Infrastructure.Sql
// {
//     public class Repository<TE,TM> : IRepository<TM, TE>
//         where TE : EntityBase, new()
//         where TM : class, new()
//     {
//         private EmployeeManagementDbContext _context;

//         public Repository(EmployeeManagementDbContext context)
//         {
//             _context = context;
//         }
//         public void Add(TM model)
//         {
//              var entity = Mapper.Map<TM,TE>(model);
//              _context.Set<TE>().Add(entity);
//         }

//         public IEnumerable<TM> AllIncluding(params Expression<Func<TE, object>>[] includeProperties)
//         {
//             var query = _context.Set<TE>();
//             foreach( var includeProperty in includeProperties)
//             {
//                 query.Include(includeProperty);
//             }
//             var entities = query.ToList();
//             var models = Mapper.Map<List<TE>,List<TM>>(entities);
//             return models;
//         }

//         public async Task<IEnumerable<TM>> AllIncludingAsync(params Expression<Func<TE, object>>[] includeProperties)
//         {
//             var query = _context.Set<TE>();
//             foreach (var includeProperty in includeProperties)
//             {
//                 query.Include(includeProperty);
//             }
//             var entities = await query.ToListAsync();
//             var models = Mapper.Map<List<TE>,List<TM>>(entities);

//             return models;
//         }

//         public void Commit()
//         {
//             _context.SaveChanges();
//         }

//         public void Delete(TM model)
//         {
//             var entity = Mapper.Map<TM,TE>(model);
//             EntityEntry dbEntityEntry = _context.Entry<TE>(entity);
//             dbEntityEntry.State = EntityState.Deleted;
//         }

//         public void Update(TM model)
//         {
//             var entity = Mapper.Map<TM,TE>(model);
//             EntityEntry dbEntityEntry = _context.Entry<TE>(entity);
//             dbEntityEntry.State = EntityState.Modified;
//         }

//         public IEnumerable<TM> FindBy(Expression<Func<TE, bool>> predicate)
//         {
//             var entities = _context.Set<TE>().Where(predicate).ToList();
//             var models = Mapper.Map<List<TE>,List<TM>>(entities);

//             return models;
//         }

//         public async Task<IEnumerable<TM>> FindByAsync(Expression<Func<TE, bool>> predicate)
//         {
//             var entities = await _context.Set<TE>().Where(predicate).ToListAsync();
//             var models = Mapper.Map<List<TE>,List<TM>>(entities);

//             return models;
//         }

//         public IEnumerable<TM> GetAll()
//         {
//             var entities = _context.Set<TE>().ToList();
//             var models = Mapper.Map<List<TE>,List<TM>>(entities);

//             return models;
//         }

//         public async Task<IEnumerable<TM>> GetAllAsync()
//         {
//             var entities = await _context.Set<TE>().ToListAsync();
//             var models = Mapper.Map<List<TE>,List<TM>>(entities);

//             return models;
//         }

//         public TM GetSingle(object id)
//         {
//             var entity = _context.Set<TE>().FirstOrDefault(e => e.Id == (int)id);
//             var model = Mapper.Map<TE,TM>(entity);

//             return model;
//         }

//         public TM GetSingle(Expression<Func<TE, bool>> predicate)
//         {
//             var entity = _context.Set<TE>().FirstOrDefault(predicate);
//             var model = Mapper.Map<TE,TM>(entity);

//             return model;
//         }

//         public async Task<TM> GetSingleAsync(object id)
//         {
//             var entity = await _context.Set<TE>().FirstOrDefaultAsync(e => e.Id == (int)id);
//             var model = Mapper.Map<TE,TM>(entity);

//             return model;
//         }
//     }
// }