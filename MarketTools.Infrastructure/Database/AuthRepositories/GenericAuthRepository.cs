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
    internal class GenericAuthRepository : GenericRepository<AutoresponderColumn>, IAuthRepository<AutoresponderColumn>
    {
        private readonly Expression<Func<AutoresponderColumn, bool>> _userCondition;
        public GenericAuthRepository(DbSet<AutoresponderColumn> dbSet, Expression<Func<AutoresponderColumn, bool>> userCondition) : base(dbSet)
        {
            _userCondition = userCondition;
        }

        public override async Task<AutoresponderColumn> FirstAsync(Expression<Func<AutoresponderColumn, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await FirstOrDefaultAsync(condition, cancellationToken)
                 ?? throw new DefaultNotFoundException();
        }

        public override async Task<IEnumerable<AutoresponderColumn>> GetRangeAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .ToListAsync(cancellationToken);
        }

        public override async Task<IEnumerable<AutoresponderColumn>> GetRangeAsync(Expression<Func<AutoresponderColumn, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .Where(condition)
                .ToListAsync(cancellationToken);
        }

        public override async Task<AutoresponderColumn?> FirstOrDefaultAsync(Expression<Func<AutoresponderColumn, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .FirstOrDefaultAsync(condition, cancellationToken);
        }

        public override async Task<bool> AnyAsync(Expression<Func<AutoresponderColumn, bool>> condition, CancellationToken cancellationToken = default)
        {
            return await DbSet
                .Where(_userCondition)
                .AnyAsync(condition, cancellationToken);
        }
    }
}
