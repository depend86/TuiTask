using System.Linq;
using TuiTask.Common.Entities;

namespace TuiTask.StandartProvider.Repositories
{
    public interface ITourRepository
    {
        IQueryable<Tour> Tours { get; }
        void Populate();
    }
}