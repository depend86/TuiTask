using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using TuiTask.Common.Entities;
using TuiTask.Common.Services.Search;
using TuiTask.Common.Services.Settings;
using TuiTask.StandartProvider.Repositories;
using Xunit;

namespace TuiTask.Tests
{
    public class StandartProviderTests
    {
        [Fact]
        public async Task SearchAsyncTest()
        {
            // arrange
            var tour1 = new Tour{Id = 1, CityFrom = new City{Id = 1}};
            var tour2 = new Tour{Id = 2, CityFrom = new City{Id = 2}};
            
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var mockSettings = fixture.Freeze<Mock<ISettings>>();
            mockSettings.Setup(x => x.ToursPackSize).Returns(1000);

            var mockTourRepository = fixture.Freeze<Mock<ITourRepository>>();
            mockTourRepository.Setup(x => x.Tours).Returns((new List<Tour>
            {
                tour1,
                tour2,
            }).AsQueryable());
            
            // act
            var sut = fixture.Create<StandartProvider.Providers.StandartProvider>();
            var tours = await sut.SearchAsync(new TourSearchRequest{DepartureCityId = 1}, CancellationToken.None);

            // assert
            Assert.Equal(1, tours.First().Id);
        }
    }
}