using Models;
using Models.DBModels;
using Repository.Interface;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Runtime.Intrinsics.X86;

namespace Repository
{
    public class BookedRideRepository : IBookedRidesRepository
    {
        private readonly AppDbContext dbContext;

        public BookedRideRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DBBookedRide Add(DBBookedRide dbBookedRide)
        {
            dbContext.BookedRides.Add(dbBookedRide);
            return dbBookedRide;
        }

        //public DBBookRide Add(DBBookRide dbBookRide)
        //{
        //    dbContext.BookedRides.Add(dbBookRide);
        //    return dbBookRide;
        //}
        //public DBBookRide Update(DBBookRide dbBookRideChanges)
        //{
        //    var dbBookRide = dbContext.BookedRides.Attach(dbBookRideChanges);
        //    dbBookRide.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    return dbBookRideChanges;
        //}
        //public DBBookRide GetById(DBBookRide dBBookRideId)
        //{
        //    DBBookRide dbBookRide = dbContext.BookedRides.Find(dBBookRideId);
        //    return dbBookRide;
        //}
        public List<DBBookedRide> GetAll()
        {

            List<DBBookedRide> dBBookRides = dbContext.BookedRides.ToList();
            return dBBookRides;
        }
    }
}