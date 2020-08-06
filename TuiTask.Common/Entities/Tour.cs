using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TuiTask.Common.Entities
{
    /// <summary>
    /// Тур
    /// </summary>
    [DataContract]
    public class Tour
    {
        /// <summary>
        /// айди
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Отель
        /// </summary>
        [DataMember(Name = "hotel")]
        public Hotel Hotel { get; set; }
        
        /// <summary>
        /// название номера
        /// </summary>
        [DataMember(Name = "roomOption")]
        public RoomOption RoomOption { get; set; }
        
        /// <summary>
        /// Город вылета
        /// </summary>
        [DataMember(Name = "cityFrom")]
        public City CityFrom { get; set; }
        
        /// <summary>
        /// Дата вылета
        /// </summary>
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// дата прилета
        /// </summary>
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Дата заезда
        /// </summary>
        [DataMember(Name = "arrivalDate")]
        public DateTime ArrivalDate { get; set; }
        
        /// <summary>
        /// количество ночей
        /// </summary>
        [DataMember(Name = "daysCount")]
        public int DaysCount { get; set; }
        
        /// <summary>
        /// цена за 1 человека
        /// </summary>
        [DataMember(Name = "priceByPerson")]
        public decimal PriceByPerson { get; set; }
        
        /// <summary>
        /// авиакомпания
        /// </summary>
        [DataMember(Name = "airline")]
        public string Airline { get; set; }
        
        /// <summary>
        ///  максимальное количество человек в номере
        /// </summary>
        [DataMember(Name = "maxPerson")]
        public int MaxPerson { get; set; }
        
        /// <summary>
        /// Провайдер
        /// </summary>
        [DataMember(Name = "provider")]
        public string Provider { get; set; }
        
        /// <summary>
        /// Общая цена тура
        /// </summary>
        [DataMember(Name = "totalPrice")]
        public decimal TotalPrice { get; set; }

        private sealed class TourEqualityComparer : IEqualityComparer<Tour>
        {
            public bool Equals(Tour x, Tour y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return Equals(x.Hotel, y.Hotel) 
                       && x.RoomOption == y.RoomOption 
                       && Equals(x.CityFrom, y.CityFrom) 
                       && x.StartDate.Date == y.StartDate.Date 
                       && x.EndDate.Date == y.EndDate.Date 
                       && x.DaysCount == y.DaysCount;
            }
            
            public int GetHashCode(Tour obj)
            {
                return HashCode.Combine(obj.Hotel, (int) obj.RoomOption, obj.CityFrom, obj.StartDate, obj.EndDate, obj.DaysCount);
            }
        }

        public static IEqualityComparer<Tour> TourComparer { get; } = new TourEqualityComparer();
    }
}