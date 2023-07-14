using AutoMapper;
using Models;
using Models.DBModels;
using Repository.Interface;
using Services.Interface;

namespace Services
{
    public class BookedRidesService : IBookedRidesService
    {
        IOfferRideService _offerRideService;
        IBookedRidesRepository _bookedRidesRepository;
        IMapper _mapper;
        IUserDetailsService _userDetailsService;
        public BookedRidesService(IOfferRideService offerRideService, IBookedRidesRepository bookedRidesRepository, IMapper mapper, IUserDetailsService userDetailsService)
        {
            _offerRideService = offerRideService;
            _bookedRidesRepository = bookedRidesRepository;
            _mapper = mapper;
            _userDetailsService = userDetailsService;
        }
        public List<BookedRide> GetBookedRides(string email)
        {
            User user = _userDetailsService.GetUserDetailsByEmail(email);

            List<DBBookedRide> dbBookedRides = _bookedRidesRepository.GetAll();
            List<BookedRide> bookedRideList = dbBookedRides.Select(dbRide =>
            {
                BookedRide bookedRide = _mapper.Map<BookedRide>(dbRide);
                bookedRide.CustomerId = user.Id;
                return bookedRide;
            }).ToList();

            return bookedRideList;
        }

    }
}
