using MarketTools.Application.Interfaces.Database;
using MarketTools.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Database
{
    internal class UnitOfWork : IUnitOfWork
    {
        protected MainAppDbContext DbContext { get; }

        public UnitOfWork(MainAppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task CommintAsync(CancellationToken cancellationToken = default)
        {
            await DbContext.SaveChangesAsync();
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public virtual IRepository<T> GetRepository<T>() where T : class
        {
            DbSet<T> set = DbContext.Set<T>();
            return new GenericRepository<T>(set);
        }

        public void Rollback()
        {
            DbContext.Dispose();
        }

        public async Task RollbackAsync()
        {
            await DbContext.DisposeAsync();
        }
    }
}
