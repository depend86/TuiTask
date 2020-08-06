using System.Collections.Generic;
using System.Runtime.Serialization;
using TuiTask.Common.Entities;

namespace TuiTask.Common.Services.Search
{
    [DataContract]
    public class TourSearchResponse
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
        
        [DataMember(Name = "tours")]
        public List<Tour> Tours { get; set; }
    }
}