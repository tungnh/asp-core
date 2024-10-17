﻿using Microsoft.EntityFrameworkCore;
using OM.Application.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OM.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(TEntity t)
        {
            await _context.Set<TEntity>().AddAsync(t);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddRange(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity t)
        {
            _context.Attach(t);
            _context.Set<TEntity>().Remove(t);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            var entityDelete = await _context.Set<TEntity>().FindAsync(id);
            _context.Attach(entityDelete);
            _context.Set<TEntity>().Remove(entityDelete);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync(); 
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<int> RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.AttachRange(entities);
            _context.Set<TEntity>().RemoveRange(entities);
            return await _context.SaveChangesAsync();
        }

        public async Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<int> Update(TEntity t)
        {
            _context.Update(t);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateRange(IEnumerable<TEntity> entities)
        {
            _context.UpdateRange(entities);
            return await _context.SaveChangesAsync();
        }
    }
}
