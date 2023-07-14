using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interface;

namespace CarPool.Controllers
{
    public class UserDetailsController : Controller
    {
        IUserDetailsService _userDetailsService;
        public UserDetailsController(IUserDetailsService userDetailsService)
        {
            _userDetailsService= userDetailsService;
        }
        [HttpGet("Email")]
        public async Task<User> GetUserDetails(string Email) 
        {
          User user = _userDetailsService.GetUserDetailsByEmail(Email);
            return user;
        }
        [HttpPost("Update")]
        public async Task<User> UpdateUserDetails(User oldUserDetails)
        {
            User user = _userDetailsService.UpdateUserDetails(oldUserDetails);
            return user;
        }
    }
}
