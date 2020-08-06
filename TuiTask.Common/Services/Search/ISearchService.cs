using System.Threading.Tasks;

namespace TuiTask.Common.Services.Search
{
    public interface ISearchService
    {
        /// <summary>
        /// Поиск туров
        /// </summary>
        /// <param name="tourSearchRequest"></param>
        /// <returns></returns>
        Task<TourSearchResponse> SearchAsync(TourSearchRequest tourSearchRequest);
    }
}