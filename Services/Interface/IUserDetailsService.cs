using Models;
namespace Services.Interface
{
    public interface IUserDetailsService
    {
        User GetUserDetailsByEmail(string email);
        User UpdateUserDetails(User user);
        //public List<User> GetUsersByofferRides(List<OfferRide> offerRides);
        List<User> GetUsers();
        User GetUserByUserId(string id);
    }
}
