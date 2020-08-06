using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Search;

namespace TuiTask.StandartProvider.Providers
{
    public interface IStandartProvider
    {
        Task<List<Tour>> SearchAsync(TourSearchRequest tourSearchRequest, CancellationToken cancellationToken);
    }
}