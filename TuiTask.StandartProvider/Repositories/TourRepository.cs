using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using TuiTask.Common.Entities;

namespace TuiTask.StandartProvider.Repositories
{
    public class TourRepository : ITourRepository
    {
        private List<Tour> tours = new List<Tour>();

        public void Populate()
        {
            Console.WriteLine("Start populate standart provider");
            
            var random = new Random((int) DateTime.Now.Ticks);
            Randomizer.Seed = random;

            var tourId = 1;
            var tourFaker = new Faker<Tour>()
                .StrictMode(true)
                .RuleFor(x => x.Id, f => tourId++)
                .RuleFor(x => x.Hotel, f => f.PickRandom(Hotel.FakeHotels))
                .RuleFor(x => x.RoomOption, f => f.PickRandom<RoomOption>())
                .RuleFor(x => x.CityFrom, f => f.PickRandom(City.FakeCities))
                .RuleFor(x => x.StartDate, f => f.Date.Future())
                .RuleFor(x => x.DaysCount, f => f.Random.Int(1, 14))
                .RuleFor(x => x.EndDate, (f, u) => u.StartDate + TimeSpan.FromDays(u.DaysCount + 1))
                .RuleFor(x => x.ArrivalDate, (f, u) => u.StartDate + TimeSpan.FromDays(1))
                .RuleFor(x => x.PriceByPerson, f => decimal.Parse(f.Commerce.Price(1000, 5000)))
                .RuleFor(x => x.Airline, f => f.Company.CompanyName())
                .RuleFor(x => x.MaxPerson, f => f.Random.Int(1, 8))
                .RuleFor(x => x.Provider, f => nameof(StandartProvider))
                .RuleFor(x => x.TotalPrice, f => 0);
                ;

            tours = tourFaker.Generate(1000000);
            
            Console.WriteLine("End populate standart provider");
        }

        public IQueryable<Tour> Tours => tours.AsQueryable();
    }
}