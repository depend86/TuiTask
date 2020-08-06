using System.Threading.Tasks;
using TuiTask.Common.Entities;

namespace TuiTask.Common.Services.Price
{
    public interface IPriceCalculator
    {
        Task CalculatePrice(Tour tour, int personCount);
    }
}