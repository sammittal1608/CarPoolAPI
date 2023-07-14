using Microsoft.EntityFrameworkCore.Update.Internal;
using Models;
namespace Services.Interface
{
    public interface IOfferRideService
    {
        OfferRide AddOfferingRide(OfferRide offerRide);
        List<OfferRide> GetAllOfferRides();
        OfferRide DeleteOfferRide(string offerRideId);
        List<OfferRide> GetOfferedRide(string userId);
        OfferRide UpdateOfferRide(OfferRide offerRide);
        OfferRide GetOfferRideByUserId(string id);
    }
}
