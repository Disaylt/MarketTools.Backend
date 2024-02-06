using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Database
{
    internal class AuthCondition<T> where T : class
    {
        public Expression<Func<T, bool>> Condition { get; }

        public AuthCondition(Expression<Func<T, bool>> userCondition)
        {
            Condition = userCondition;
        }
    }
}
