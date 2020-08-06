using System;
using System.Linq.Expressions;

namespace TuiTask.Common.Repositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}