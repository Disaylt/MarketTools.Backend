using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Database.Repositories
{
    internal class GenericRepository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> DbSet { get; }

        public GenericRepository(DbSet<T> dbSet)
        {
            DbSet = dbSet;
        }

        public virtual IQueryable<T> GetAsQueryable()
        {
            return DbSet.AsQueryable();
        }

        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(cancellationToken);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(condition, cancellationToken);
        }

        public virtual async Task ExecuteDeleteAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            await DbSet.Where(condition)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet.AnyAsync(condition, cancellationToken);
        }

        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(condition, cancellationToken)
                ?? throw new AppNotFoundException();
        }

        public virtual async Task<T> FirstAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(cancellationToken)
                ?? throw new AppNotFoundException();
        }

        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(condition, cancellationToken);
        }

        public virtual async Task<T?> FirstOrDefaultAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await DbSet.AddRangeAsync(entities, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(condition)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetRangeAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        public virtual void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
