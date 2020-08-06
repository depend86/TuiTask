using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Search;

namespace TuiTask.OtherProvider.Providers
{
    public interface IOtherProvider
    {
        Task<List<Tour>> SearchAsync(TourSearchRequest tourSearchRequest, CancellationToken cancellationToken);
    }
}