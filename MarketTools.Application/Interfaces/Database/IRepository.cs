using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Database
{
    public interface IRepository<T> where T : class
    {
        public Task ExecuteDeleteAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        public Task<T> FirstAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        public Task AddAsync(T entity, CancellationToken cancellationToken = default);
        public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        public Task<IEnumerable<T>> GetRangeAsync(Expression<Func<T, bool>> condition, CancellationToken cancellationToken = default);
        public Task<IEnumerable<T>> GetRangeAsync(CancellationToken cancellationToken = default);
        public void Remove(T entity);
        public void RemoveRange(IEnumerable<T> entities);
        public void UpdateRange(IEnumerable<T> entities);
        public void Update(T entity);
    }
}
