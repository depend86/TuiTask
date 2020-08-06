using System.Threading.Tasks;
using TuiTask.Common.Entities;

namespace TuiTask.Common.Services.Price
{
    public class PriceCalculator : IPriceCalculator
    {
        public Task CalculatePrice(Tour tour, int personCount)
        {
            tour.TotalPrice = tour.PriceByPerson * personCount;
            return Task.CompletedTask;
        }
    }
}