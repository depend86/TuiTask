using System.Collections.Generic;
using System.Runtime.Serialization;
using Bogus;

namespace TuiTask.Common.Entities
{
    /// <summary>
    /// Отель
    /// </summary>
    [DataContract]
    public class Hotel
    {
        /// <summary>
        /// айди
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// название
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// адрес
        /// </summary>
        [DataMember(Name = "address")]
        public string Address { get; set; }
        
        /// <summary>
        /// город
        /// </summary>
        [DataMember(Name = "city")]
        public City City { get; set; }
        
        /// <summary>
        /// год постройки
        /// </summary>
        [DataMember(Name = "yearEstablished")]
        public int YearEstablished { get; set; }

        protected bool Equals(Hotel other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Hotel) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        #region Fake Hotels

        static Hotel()
        {
            var hotelId = 1;
            var hotelFaker = new Faker<Hotel>()
                .RuleFor(x => x.Id, f => hotelId++)
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.City, f => f.PickRandom(Entities.City.FakeCities))
                .RuleFor(x => x.YearEstablished, f => f.Random.Int(1900, 2000));

            FakeHotels = hotelFaker.Generate(10000);
        }

        public static List<Hotel> FakeHotels { get; }

        #endregion
    }
}