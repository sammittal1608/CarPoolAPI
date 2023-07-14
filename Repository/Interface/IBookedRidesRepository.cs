using Models;
using Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBookedRidesRepository
    {
        List<DBBookedRide> GetAll();
        DBBookedRide Add(DBBookedRide dbBookedRide);
    }
}
