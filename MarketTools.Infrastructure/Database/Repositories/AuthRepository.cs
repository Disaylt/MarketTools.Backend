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
    internal class AuthRepository<T> : GenericRepository<T>, IRepository<T> where T : class
    {
        private readonly Expression<Func<T, bool>> _userCondition;
        public AuthRepository(DbSet<T> dbSet, Expression<Func<T, bool>> userCondition) : base(dbSet)
        {
            _userCondition = userCondition;
        }

        public override IQueryable<T> GetAsQueryable()
        {
            return DbSet.Where(_userCondition)
                .AsQueryable();
        }

        public override async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.CountAsync(_userCondition, cancellationToken);
        }

        public override async Task<int> CountAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(_userCondition)
                .CountAsync(condition, cancellationToken);
        }

        public override async Task ExecuteDeleteAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            await DbSet.Where(_userCondition)
                .Where(condition)
                .ExecuteDeleteAsync(cancellationToken);
        }

        public override async Task<T> FirstAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await FirstOrDefaultAsync(condition, cancellationToken)
                 ?? throw new AppNotFoundException();
        }

        public override async Task<IEnumerable<T>> GetRangeAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .ToListAsync(cancellationToken);
        }

        public override async Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .Where(condition)
                .ToListAsync(cancellationToken);
        }

        public override async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .FirstOrDefaultAsync(condition, cancellationToken);
        }

        public override async Task<bool> AnyAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .AnyAsync(condition, cancellationToken);
        }
    }
}
