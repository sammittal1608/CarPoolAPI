using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IMatchingRidesService
    {
        List<MatchingRideResponse> GetMatchingRide(MatchingRideRequest bookRide);
        MatchingRideResponse AddBookingRide(MatchingRideResponse bookRideResponse);

    }
}
