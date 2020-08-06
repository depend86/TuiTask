using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Dictionary;
using TuiTask.OtherProvider.Repositories;
using TuiTask.StandartProvider.Repositories;

namespace TuiTask.Aggregator
{
    public class DictionaryAggregator : IDictService
    {
        private const int CACHE_SECONDS = 300;
        
        private ITourRepository _tourRepository;
        private IOtherTourRepository _otherTourRepository;
        
        private IMemoryCache _memoryCache;
        private CancellationTokenSource _resetCacheToken = new CancellationTokenSource();

        public DictionaryAggregator(ITourRepository tourRepository, IOtherTourRepository otherTourRepository, IMemoryCache memoryCache)
        {
            _tourRepository = tourRepository;
            _otherTourRepository = otherTourRepository;
            _memoryCache = memoryCache;
        }

        public void ClearCache()
        {
            if (_resetCacheToken != null && !_resetCacheToken.IsCancellationRequested && _resetCacheToken.Token.CanBeCanceled)
            {
                _resetCacheToken.Cancel();
                _resetCacheToken.Dispose();
            }

            _resetCacheToken = new CancellationTokenSource();
        }

        public async Task<List<City>> GetDepartureCitiesAsync(CancellationToken cancellationToken)
        {
            return await _memoryCache.GetOrCreateAsync("departureCities", entry =>
            {
                var cities =
                    Enumerable.Empty<City>()
                        .Union(_tourRepository.Tours.Select(x => x.CityFrom))
                        .Union(_otherTourRepository.Tours.Select(x => x.CityFrom))
                    .Distinct()
                    .OrderBy(x => x.Id)
                    .ToList();
                entry.AbsoluteExpiration = DateTimeOffset.Now + TimeSpan.FromSeconds(CACHE_SECONDS);

                return Task.FromResult(cities);
            });
        }

        public async Task<List<Country>> GetAllCountriesAsync(CancellationToken cancellationToken)
        {
            return await _memoryCache.GetOrCreateAsync("allCountries", entry =>
            {
                var countries = 
                    Enumerable.Empty<Country>()
                        .Union(_tourRepository.Tours.Select(x => x.Hotel.City.Country))
                        .Union(_otherTourRepository.Tours.Select(x => x.Hotel.City.Country))
                    .Distinct()
                    .OrderBy(x => x.Name)
                    .ToList();
                entry.AbsoluteExpiration = DateTimeOffset.Now + TimeSpan.FromSeconds(CACHE_SECONDS);

                return Task.FromResult(countries);
            });
        }

        public async Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken)
        {
            return await _memoryCache.GetOrCreateAsync("cities", entry =>
            {
                var cities = 
                    Enumerable.Empty<City>()
                        .Union(_tourRepository.Tours.Select(x => x.Hotel.City))
                        .Union(_otherTourRepository.Tours.Select(x => x.Hotel.City))
                    .Distinct()
                    .OrderBy(x => x.Id)
                    .ToList();
                entry.AbsoluteExpiration = DateTimeOffset.Now + TimeSpan.FromSeconds(CACHE_SECONDS);

                return Task.FromResult(cities);
            });
        }

        public async Task<List<Hotel>> GetHotelsAsync(CancellationToken cancellationToken)
        {
            return await _memoryCache.GetOrCreateAsync("hotels", entry =>
            {
                var hotels = 
                    Enumerable.Empty<Hotel>()
                        .Union(_tourRepository.Tours.Select(x => x.Hotel))
                        .Union(_otherTourRepository.Tours.Select(x => x.Hotel))
                    .Distinct()
                    .OrderBy(x => x.Id)
                    .ToList();
                entry.AbsoluteExpiration = DateTimeOffset.Now + TimeSpan.FromSeconds(CACHE_SECONDS);

                return Task.FromResult(hotels);
            });
        }

        public async Task<Hotel> GetHotelAsync(HotelRequest hotelRequest, CancellationToken cancellationToken)
        {
            var key = $"hotel_{hotelRequest.Id}";
            return await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                var hotel = Enumerable.Empty<Hotel>()
                    .Union(_tourRepository.Tours.Select(x => x.Hotel))
                    .Union(_otherTourRepository.Tours.Select(x => x.Hotel))
                    .FirstOrDefault(x => x.Id == hotelRequest.Id);
                entry.AbsoluteExpiration = DateTimeOffset.Now + TimeSpan.FromSeconds(CACHE_SECONDS);

                return Task.FromResult(hotel);
            });
        }
    }
}