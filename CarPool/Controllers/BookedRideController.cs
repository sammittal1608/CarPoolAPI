using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;

namespace CarPool.Controllers
{
    public class BookedRideController : Controller
    {
        IBookedRidesService _bookedRidesService;
        public BookedRideController(IBookedRidesService bookedRidesService) 
        {
            _bookedRidesService= bookedRidesService;
        }
        [HttpGet("")]
        public List<BookedRide> GetAllBookedRide(string email)
        {
            List<BookedRide> BookedRides = _bookedRidesService.GetBookedRides(email);
            return BookedRides;
        }
        //public BookedRide Add(BookedRide bookedRide)
        //{
        //    BookedRide bookRide = _bookedRidesService.AddBookedRide(bookedRide);
        //    return bookRide;
        //}
    }
}
