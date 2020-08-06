using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Dictionary;
using TuiTask.Common.Services.Search;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TourController : Controller
    {
        private ISearchService _searchService;
        private IDictService _dictService;

        public TourController(ISearchService searchService, IDictService dictService)
        {
            _searchService = searchService;
            _dictService = dictService;
        }

        /// <summary>
        /// Поиск туров
        /// </summary>
        /// <param name="tourSearchRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        [ProducesResponseType(typeof(TourSearchResponse), 200)]
        public async Task<IActionResult> SearchAsync([FromBody] TourSearchRequest tourSearchRequest)
        {
            var tourSearchResponse = await _searchService.SearchAsync(tourSearchRequest);
            return Ok(tourSearchResponse);
        }
        
        /// <summary>
        /// Города вылета
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("departureCities")]
        [ProducesResponseType(typeof(List<City>), 200)]
        public async Task<IActionResult> GetDepartureCitiesAsync()
        {
            var departureCities = await _dictService.GetDepartureCitiesAsync(HttpContext.RequestAborted);
            return Ok(departureCities);
        }
        
        /// <summary>
        /// все города прилета (города в которых есть отели)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("hotelCities")]
        [ProducesResponseType(typeof(List<City>), 200)]
        public async Task<IActionResult> GetCitiesAsync()
        {
            var cities = await _dictService.GetCitiesAsync(HttpContext.RequestAborted);
            return Ok(cities);
        }
        
        /// <summary>
        /// Страны
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("countries")]
        [ProducesResponseType(typeof(List<Country>), 200)]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var allCountries = await _dictService.GetAllCountriesAsync(HttpContext.RequestAborted);
            return Ok(allCountries);
        }
        
        /// <summary>
        /// Все отели
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("hotels")]
        [ProducesResponseType(typeof(List<Country>), 200)]
        public async Task<IActionResult> GetHotelsAsync()
        {
            var hotels = await _dictService.GetHotelsAsync(HttpContext.RequestAborted);
            return Ok(hotels);
        }   
        
        /// <summary>
        /// Отель по айди
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("hotel/{id}")]
        [ProducesResponseType(typeof(List<Country>), 200)]
        public async Task<IActionResult> GetHotelAsync(int id)
        {
            var hotel = await _dictService.GetHotelAsync(new HotelRequest{Id = id}, HttpContext.RequestAborted );
            return Ok(hotel);
        }         
    }
}