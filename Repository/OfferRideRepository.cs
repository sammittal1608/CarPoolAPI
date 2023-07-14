using Microsoft.EntityFrameworkCore;
using Models;
using Models.DBModels;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OfferRideRepository : IOfferRideRepository
    {
        private readonly AppDbContext _dbContext;
        public OfferRideRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;       
        }
        public DBOfferRide Add(DBOfferRide dbOfferRide)
        {
            _dbContext.OfferRides.Add(dbOfferRide);
            return dbOfferRide;
        }
        public DBOfferRide Update(DBOfferRide dbOfferRideChanges)
        {
          var dbOfferRide =  _dbContext.OfferRides.Attach(dbOfferRideChanges);
            dbOfferRide.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return dbOfferRideChanges;

        }
        public List<DBOfferRide> GetAll()
        {
            List<DBOfferRide> dBOfferRides  = _dbContext.OfferRides.ToList();
            return dBOfferRides;
        }
        
        public DBOfferRide GetById(string dbOfferRideId)
        {
            DBOfferRide dbOfferRide = _dbContext.OfferRides.Find(dbOfferRideId);
            return dbOfferRide;
        }
        public DBOfferRide Delete(string dbOfferRideId)
        {
            DBOfferRide dbOfferRide = GetById(dbOfferRideId);
            if (dbOfferRide != null)
            {
                _dbContext.OfferRides.Remove(dbOfferRide);
                _dbContext.SaveChanges();
            }
            return dbOfferRide;
        }
    }
}
