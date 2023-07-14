using Models;
using Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserDetailsRepository
    {
        DBUser AddUser(DBUser dbUser);
        DBUser GetUserById(string Id);
        DBUser GetUserByEmail(string email);
        DBUser UpdateUserDetails(DBUser user);
        List<DBUser> GetUsers();
    }
}
