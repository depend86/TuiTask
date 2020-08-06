using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using TuiTask.Common.Entities;
using TuiTask.Common.Repositories;

namespace TuiTask.Common.Services.Search
{
    [DataContract]
    public class TourSearchRequest : ISpecification<Tour>
    {
        /// <summary>
        /// Город вылета
        /// </summary>
        [DataMember(Name = "departureCityId")]
        public int? DepartureCityId { get; set; }
        
        /// <summary>
        /// Город тура
        /// </summary>
        [DataMember(Name = "tourCityId")] 
        public int? TourCityId { get; set; }
        
        /// <summary>
        /// Дата начала
        /// </summary>
        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; set; }
        
        /// <summary>
        /// Количество ночей «от»
        /// </summary>
        [DataMember(Name = "minDaysCount")]
        public int? MinDaysCount { get; set; }
        
        /// <summary>
        /// Количество ночей «до»
        /// </summary>
        [DataMember(Name = "maxDaysCount")]
        public int? MaxDaysCount { get; set; }
        
        /// <summary>
        /// Количество человек
        /// </summary>
        [DataMember(Name = "personCount")]
        public int? PersonCount { get; set; }

        /// <summary>
        /// Сортировка 
        /// </summary>
        [DataMember(Name = "sort")]
        public string Sort { get; set; } = SearchRequestSort.byDate.ToString();

        [IgnoreDataMember]
        public Expression<Func<Tour, bool>> Criteria
        {
            get
            {
                Expression<Func<Tour, bool>> result = x => true;

                if (DepartureCityId.HasValue && DepartureCityId.Value > 0)
                {
                    var prefix = result.Compile();
                    result = x => prefix(x) && x.CityFrom.Id == DepartureCityId.Value;
                }

                if (TourCityId.HasValue && TourCityId.Value > 0)
                {
                    var prefix = result.Compile();
                    result = x => prefix(x) && x.Hotel.City.Id == TourCityId.Value;
                }

                if (StartDate.HasValue && StartDate.Value > DateTime.Now)
                {
                    var prefix = result.Compile();
                    result = x => prefix(x) && x.StartDate.Date == StartDate.Value.Date;
                }

                if (MinDaysCount.HasValue && MinDaysCount.Value > 0)
                {
                    var prefix = result.Compile();
                    result = x => prefix(x) && x.DaysCount >= MinDaysCount.Value;
                }

                if (MaxDaysCount.HasValue && MaxDaysCount.Value > 0)
                {
                    var prefix = result.Compile();
                    result = x => prefix(x) && x.DaysCount <= MaxDaysCount.Value;
                }

                if (PersonCount.HasValue && PersonCount.Value > 0)
                {
                    var prefix = result.Compile();
                    result = x => prefix(x) && x.MaxPerson <= PersonCount.Value;
                }

                return result;
            }
        }
    }
    
    public static class TourSearchRequestSorting
    {
        public static IOrderedQueryable<Tour> ApplySorting(this IQueryable<Tour> tours, TourSearchRequest tourSearchRequest)
        {
            var searchRequestSort = Enum.TryParse(tourSearchRequest.Sort, true, out SearchRequestSort result)
                ? result
                : SearchRequestSort.byDate;
            
            if (searchRequestSort != SearchRequestSort.byDateDesc && searchRequestSort != SearchRequestSort.byPriceDesc)
            {
                switch (searchRequestSort)
                {
                    case SearchRequestSort.byDate:
                        return tours.OrderBy(x => x.StartDate);
                    case SearchRequestSort.byName:
                        return tours.OrderBy(x => x.Hotel.Name);
                    case SearchRequestSort.byPrice:
                        return tours.OrderBy(x => x.PriceByPerson * tourSearchRequest.PersonCount.GetValueOrDefault(1));
                }
            }
            else
            {
                switch (searchRequestSort)
                {
                    case SearchRequestSort.byDateDesc:
                        return tours.OrderByDescending(x => x.ArrivalDate);
                    case SearchRequestSort.byPriceDesc:
                        return tours.OrderByDescending(x => x.PriceByPerson * tourSearchRequest.PersonCount.GetValueOrDefault(1));
                }
            }
            
            return tours.OrderBy(x => x.StartDate);
        }
    }
}