using Models;
using Models.DBModels;
using Repository.Interface;
namespace Repository
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private AppDbContext _dbContext;
        public UserDetailsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DBUser AddUser(DBUser userDetails)
        {
            _dbContext.Users.Add(userDetails);
             _dbContext.SaveChanges();
            return userDetails;
        }

        public DBUser GetUserById(string Id)
        {
            var result = _dbContext.Users.FirstOrDefault(e => e.Id == Id);
            if (result != null)
            {
                return result;
            }
            return result;
        }
        public DBUser GetUserByEmail(string email)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            return dbUser;
        }
        public DBUser UpdateUserDetails(DBUser userDetails)
        {
            var dbUser =_dbContext.Users.Attach(userDetails);
            dbUser.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return userDetails;
        }
        public List<DBUser> GetUsers() 
        {
            return _dbContext.Users.ToList();
        }
    }
}
