using Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IOfferRideRepository
    {
        DBOfferRide Add(DBOfferRide dbOfferRide);
        DBOfferRide Update(DBOfferRide dbOfferRide);
        DBOfferRide Delete(string dbOfferRide);
        List<DBOfferRide> GetAll();
        DBOfferRide GetById(string id);
    }
}
