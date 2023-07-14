using AutoMapper;
using Microsoft.AspNet.Identity;
using Models;
using Models.DBModels;
using Repository.Interface;
using Services.Interface;

namespace Services
{
    public class MatchingService : IMatchingRidesService
    {
        IMatchingRidesService _matchingRidesService;
        IOfferRideService _offerRidesService;
        IUserDetailsService _userDetailsService;
        IMapper _mapper;
        IBookedRidesRepository _bookedRidesRepository;
        public MatchingService(IMatchingRidesService bookRidesService, IOfferRideService offerRideService,IUserDetailsService userDetailsService,IMapper mapper,IBookedRidesRepository bookedRidesRepository) 
        {
            _matchingRidesService = bookRidesService;
            _offerRidesService = offerRideService;
            _userDetailsService= userDetailsService;
            _bookedRidesRepository = bookedRidesRepository;
            _mapper = mapper;
        }
        public List<MatchingRideResponse> GetMatchingRide(MatchingRideRequest machingRideRequest)
        {
            List<OfferRide> offerRides = _offerRidesService.GetAllOfferRides();
            List<MatchingRideResponse> matchingRidesResponse = new List<MatchingRideResponse>();
            MatchingRideResponse matchingRideResponse = new MatchingRideResponse();
            User customer = _userDetailsService.GetUserDetailsByEmail(machingRideRequest.Email);
            //User user = GetUserByEmail(mach.Email)
            foreach (OfferRide offerRide in offerRides)
            {
                if (machingRideRequest.Source == offerRide.Source && machingRideRequest.Destination == offerRide.Destination && machingRideRequest.RideValidFrom == offerRide.RideValidFrom && machingRideRequest.RideVaildTill == offerRide.RideValidTill)
                {
                    User user = _userDetailsService.GetUserByUserId(offerRide.OwnerId);
                    matchingRideResponse.FirstName = user.FirstName;
                    matchingRideResponse.LastName = user.LastName;
                    matchingRideResponse.OwnerId = user.Id;
                    matchingRideResponse.Destination = offerRide.Destination;
                    matchingRideResponse.Source = offerRide.Source;
                    matchingRideResponse.Date = offerRide.Date;
                    matchingRideResponse.CustomerId = customer.Id;
                    matchingRideResponse.ValidFrom = offerRide.RideValidFrom;
                    matchingRideResponse.ValidTill = offerRide.RideValidTill;
                    matchingRideResponse.Seats = offerRide.AvailableSeats;
                    matchingRideResponse.Price = offerRide.Price;
                    matchingRidesResponse.Add(matchingRideResponse);
                }
            }
            return matchingRidesResponse;
        }
        public MatchingRideResponse AddBookingRide(MatchingRideResponse bookingRideReponse)
        {
            OfferRide offerRide = _offerRidesService.GetOfferRideByUserId(bookingRideReponse.OwnerId);
            offerRide.AvailableSeats--;
            offerRide.IsRideBooked = true;
            _offerRidesService.UpdateOfferRide(offerRide);
            DBBookedRide dbBookedRide = _mapper.Map<DBBookedRide>(bookingRideReponse);
            dbBookedRide = _bookedRidesRepository.Add(dbBookedRide);
            MatchingRideResponse addedBookedRide = _mapper.Map<MatchingRideResponse>(dbBookedRide);
            return addedBookedRide;
        }
    }
}
