using System.Collections.Generic;
using System.Runtime.Serialization;
using Bogus;

namespace TuiTask.Common.Entities
{
    /// <summary>
    /// Город
    /// </summary>
    [DataContract]
    public class City
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
        /// страна
        /// </summary>
        [DataMember(Name = "country")]
        public Country Country { get; set; }

        protected bool Equals(City other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((City) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        #region Fake Cities
        
        static City()
        {
            var cityId = 1;
            var cityFaker = new Faker<City>()
                .RuleFor(x => x.Id, f => cityId++)
                .RuleFor(x => x.Name, f => f.Address.City())
                .RuleFor(x => x.Country, f => f.PickRandom(Country.Countries));
            
            FakeCities = cityFaker.Generate(1000);
        }

        public static List<City> FakeCities { get; }
        
        #endregion
    }
}