using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookedRide
    {
        public string OwenerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public float Price { get; set; }
        public int AvailalbeSeats { get; set; }
    }
}
