using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Search;
using TuiTask.Common.Services.Settings;
using TuiTask.OtherProvider.Providers;
using TuiTask.StandartProvider.Providers;

namespace TuiTask.Aggregator
{
    public class SearchAggregator : ISearchService
    {
        private IStandartProvider _standartProvider;
        private IOtherProvider _otherProvider;
        private ISettings _settings;

        public SearchAggregator(IStandartProvider standartProvider, IOtherProvider otherProvider, ISettings settings)
        {
            _standartProvider = standartProvider;
            _otherProvider = otherProvider;
            _settings = settings;
        }

        public async Task<TourSearchResponse> SearchAsync(TourSearchRequest tourSearchRequest)
        {
            var cts = new CancellationTokenSource();
            
            var standartProviderSearchTask = _standartProvider.SearchAsync(tourSearchRequest, cts.Token);
            var otherProviderSearchTask = _otherProvider.SearchAsync(tourSearchRequest, cts.Token);

            var searchTasks = new[] {standartProviderSearchTask, otherProviderSearchTask};
            await Task.WhenAny(Task.WhenAll(searchTasks), Task.Delay(_settings.MaxWaitTime));

            cts.Cancel();
            
            var completedResults =
                searchTasks
                    .Where(t => t.Status == TaskStatus.RanToCompletion)
                    .Select(t => t.Result)
                    .ToList();

            var tours = completedResults
                .SelectMany(x => x)
                .GroupBy(x => x, Tour.TourComparer)
                .Select(tourGroup =>
                {
                    if (tourGroup.Count() == 1)
                        return tourGroup.First();

                    var minPriceTour = tourGroup.OrderBy(x => x.TotalPrice).First();
                    var preferedTour = tourGroup.FirstOrDefault(x => x.Provider.Equals(_settings.PreferedProviderName));

                    if (preferedTour != null && preferedTour.TotalPrice < minPriceTour.TotalPrice * _settings.MaxPreferedProviderPriceFactor)
                        return preferedTour;
                    else
                        return minPriceTour;
                })
                .AsQueryable()
                .ApplySorting(tourSearchRequest)
                .ToList();

            var result = new TourSearchResponse
            {
                Status = "xz",
                Tours = tours
            };
            return result;
        }
    }
}