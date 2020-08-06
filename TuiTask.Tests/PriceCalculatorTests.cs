using System.Threading.Tasks;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Price;
using Xunit;

namespace TuiTask.Tests
{
    public class PriceCalculatorTests
    {
        [Fact]
        public async Task CalculatePriceTest()
        {
            // arrange
            var tour = new Tour {PriceByPerson = 10m};
            
            // act
            var sut = new PriceCalculator();
            await sut.CalculatePrice(tour, 2);

            // assert
            Assert.Equal(20m, tour.TotalPrice);
        }
    }
}