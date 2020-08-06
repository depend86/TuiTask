using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TuiTask.Common.Entities;
using TuiTask.Common.Extensions;
using TuiTask.Common.Services.Price;
using TuiTask.Common.Services.Search;
using TuiTask.Common.Services.Settings;
using TuiTask.StandartProvider.Repositories;

namespace TuiTask.StandartProvider.Providers
{
    public class StandartProvider : IStandartProvider
    {
        private ITourRepository _tourRepository;
        private IPriceCalculator _priceCalculator;
        private ISettings _settings;

        public StandartProvider(ITourRepository tourRepository, IPriceCalculator priceCalculator, ISettings settings)
        {
            _tourRepository = tourRepository;
            _priceCalculator = priceCalculator;
            _settings = settings;
        }

        public async Task<List<Tour>> SearchAsync(TourSearchRequest tourSearchRequest, CancellationToken cancellationToken)
        {
            var tours = _tourRepository.Tours
                .Where(tourSearchRequest.Criteria)
                .ApplySorting(tourSearchRequest)
                .Take(_settings.ToursPackSize)
                .ToList();

            var personCount = tourSearchRequest.PersonCount.GetValueOrDefault(_settings.DefaultPersonCount);
            await tours.ForEachAsync(Environment.ProcessorCount, x => _priceCalculator.CalculatePrice(x, personCount));

            var random = new Random((int) DateTime.Now.Ticks);
            await Task.Delay(random.Next(3000, 17000), cancellationToken);

            return tours;
        }
    }
}