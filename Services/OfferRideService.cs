using AutoMapper;
using Models;
using Models.DBModels;
using Repository.Interface;
using Services.Interface;

namespace Services
{
    public class OfferRideService : IOfferRideService
    {
        IOfferRideRepository _offerRideRepository;
        IMapper _mapper;
        IUserDetailsService _userDetailsService;
        public OfferRideService(IOfferRideRepository offerRideRepository, IMapper mapper, IUserDetailsService userDetailsService)
        {
            _offerRideRepository = offerRideRepository;
            _userDetailsService = userDetailsService;
            _mapper = mapper;
        }
        public OfferRide AddOfferingRide(OfferRide offerRide)
        {
            var dbOfferRide = _mapper.Map<DBOfferRide>(offerRide);
            dbOfferRide = _offerRideRepository.Add(dbOfferRide);
            offerRide = _mapper.Map<OfferRide>(dbOfferRide);
            return offerRide;
        }
        public List<OfferRide> GetAllOfferRides()
        {
            List<DBOfferRide> dbOfferRides = _offerRideRepository.GetAll();
            List<OfferRide> offerRides = _mapper.Map<List<OfferRide>>(dbOfferRides);
            return offerRides;
        }
        public OfferRide DeleteOfferRide(string offerRideId)
        {
            var dbOfferRide = _offerRideRepository.Delete(offerRideId);
            var offerRide = _mapper.Map<OfferRide>(dbOfferRide);
            return offerRide;
        }

        public List<OfferRide> GetOfferedRide(string email)
        {
            List<OfferRide> offerRides = GetAllOfferRides();
            User user = _userDetailsService.GetUserDetailsByEmail(email);
            List<OfferRide> offerRideList = new List<OfferRide>();
            foreach (OfferRide offerRide in offerRides)
            {
                offerRide.OwnerId = user.Id;
                offerRideList.Add(offerRide);
            }
            return offerRides;
        }

        public OfferRide UpdateOfferRide(OfferRide offerRide)
        {
            DBOfferRide dbOfferRide = _mapper.Map<DBOfferRide>(offerRide);
            dbOfferRide = _offerRideRepository.Update(dbOfferRide);
            OfferRide updatedOfferRide = _mapper.Map<OfferRide>(dbOfferRide);
            return updatedOfferRide;
        }

        public OfferRide GetOfferRideByUserId(string userId)
        {

            List<OfferRide> offerRides = GetAllOfferRides();
            OfferRide offerRide = offerRides.FirstOrDefault(o => o.OwnerId== userId);
            return offerRide;

        }
    }
}