using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.EFCore.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly TtnContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TtnContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            var guid = Guid.NewGuid();
            entity.F_GUID = guid;

            var result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(bool includeDeleted = false)
        {
            if (includeDeleted)
            {
                return await _dbSet.ToListAsync();
            }
            else
            {
                return await _dbSet.Where(x => x.F_DEL == 0).ToListAsync();
            }
        }

        public async Task<T> GetByFId(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.F_ID == id);
        }

        public void Remove(T entity)
        {
            entity.F_DEL = 1;
            Update(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
