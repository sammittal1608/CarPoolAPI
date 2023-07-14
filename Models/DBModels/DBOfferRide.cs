using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class DBOfferRide
    {
        public User User { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime RideValidFrom { get; set; }
        public DateTime RideValidTill { get; set; }
        public int AvailableSeats { get; set; }
        public List<string> IntermediaryStops { get; set; }
        public float Price { get; set; }
        public bool IsRideBooked { get; set; }
        public string CustomerId { get; set; }
    }
}
