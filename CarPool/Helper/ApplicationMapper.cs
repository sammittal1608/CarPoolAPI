using AutoMapper;
using Models;
using Models.DBModels;

namespace CarPool.Helper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<OfferRide, DBOfferRide>()
            .ReverseMap();
        }
    }
}
