using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchingRideController : Controller
    {
        IMatchingRidesService _matchingRidesService;
        public MatchingRideController(IMatchingRidesService matchingRidesService) 
        {
            _matchingRidesService = matchingRidesService;
        }
        [HttpGet("BookRide")]
        public async Task<List<MatchingRideResponse>> GetMatchingRide(MatchingRideRequest matchingRide)
        {
            List<MatchingRideResponse> matchingRidesReponse = _matchingRidesService.MatchingRide(matchingRide);
            return matchingRidesReponse;
        }
        [HttpPut("BookingRide")]
        public async Task<MatchingRideResponse> AddBookingRide(MatchingRideResponse bookingRideRequest)
        {
            MatchingRideResponse bookingRideResponse = _matchingRidesService.AddBookingRide(bookingRideRequest);
            return bookingRideResponse;
        }
        //[HttpPost("")]
        //public BookRide BookRide(BookRide bookRide)
        //{
        //    _carPoolService.GetAllOfferRides();
        //}
    }
}
