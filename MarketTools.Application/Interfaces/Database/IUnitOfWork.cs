using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Database
{
    public interface IUnitOfWork
    {
        public IRepository<T> GetRepository<T>() where T : class;
        public void Commit();
        public void Rollback();
        public Task CommitAsync(CancellationToken cancellationToken = default);
        public Task RollbackAsync();
        public Task UseCommit(bool isUse, CancellationToken cancellationToken = default);
    }
}
