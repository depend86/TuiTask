using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TuiTask.Common.Entities;

namespace TuiTask.Common.Services.Dictionary
{
    /// <summary>
    /// Справочные данные
    /// </summary>
    public interface IDictService
    {
        /// <summary>
        /// Очиста кеша
        /// </summary>
        void ClearCache();
        
        /// <summary>
        /// все города вылета
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<City>> GetDepartureCitiesAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// все страны
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Country>> GetAllCountriesAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// все города прилета (города в которых есть отели)
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<City>> GetCitiesAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// Получение всех отелей
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Hotel>> GetHotelsAsync(CancellationToken cancellationToken);
        
        /// <summary>
        /// Получение отеля по айди
        /// </summary>
        /// <param name="hotelRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Hotel> GetHotelAsync(HotelRequest hotelRequest, CancellationToken cancellationToken);
    }
}