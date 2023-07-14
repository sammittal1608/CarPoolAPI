using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DBModels;
using Services;
using Services.Interface;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferRideController : Controller
    {
        IOfferRideService _offerRideService;
        public OfferRideController(IOfferRideService offerRideService)
        {
            _offerRideService = offerRideService;
        }

        [HttpPost("")]
        public OfferRide OfferARide(OfferRide offerRide)
        {
            OfferRide addedOfferRide = _offerRideService.AddOfferingRide(offerRide);
            return addedOfferRide;
        }

        [HttpGet("")]
        public List<OfferRide> GetAll()
        {
            List<OfferRide> offerRides = _offerRideService.GetAllOfferRides();
            return offerRides;
        }
        [HttpDelete("offerRideId")]
        public OfferRide Delete(string OfferRideId)
        {
            OfferRide offerRide = _offerRideService.DeleteOfferRide(OfferRideId);
            return offerRide;
        }
        [HttpPut("UserId")]
        public List<OfferRide> GetOfferedRides(string email)
        {
            List<OfferRide> offeredRides = _offerRideService.GetOfferedRide(email);
            return offeredRides;
        }
    }
}
