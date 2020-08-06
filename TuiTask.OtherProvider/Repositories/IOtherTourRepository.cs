using System.Linq;
using TuiTask.Common.Entities;

namespace TuiTask.OtherProvider.Repositories
{
    public interface IOtherTourRepository
    {
        IQueryable<Tour> Tours { get; }
        void Populate();
    }
}