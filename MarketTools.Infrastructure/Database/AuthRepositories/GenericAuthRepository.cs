using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Database.AuthRepositories
{
    internal class GenericAuthRepository<T> : GenericRepository<T>, IAuthRepository<T> where T : class
    {
        private readonly Expression<Func<T, bool>> _userCondition;
        public GenericAuthRepository(DbSet<T> dbSet, Expression<Func<T, bool>> userCondition) : base(dbSet)
        {
            _userCondition = userCondition;
        }

        public override async Task<int> CounAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default)
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
                 ?? throw new DefaultNotFoundException();
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
