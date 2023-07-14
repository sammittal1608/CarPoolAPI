using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class DBBookedRide
    {
         string Id { get; set; }
         string CustomerId { get; set; }
        string Source { get; set; }
        string Destination { get; set; }
        DateTime Date { get; set; }
        DateTime Time { get; set; }
    }
}
