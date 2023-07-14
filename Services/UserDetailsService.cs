using AutoMapper;
using Models;
using Models.DBModels;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserDetailsService : IUserDetailsService
    {
        IUserDetailsRepository _userDetailsRepository;
        IMapper _mapper;
        public UserDetailsService(IUserDetailsRepository userDetailsRepository,IMapper mapper)
        {
            _userDetailsRepository = userDetailsRepository;
            _mapper = mapper;
        }
        public User GetUserDetailsByEmail(string email)
        {
           DBUser dbUser = _userDetailsRepository.GetUserByEmail(email);
            User user = _mapper.Map<User>(dbUser);
            return user;

        }

        public User UpdateUserDetails(User user)
        {
            DBUser dbUser = _mapper.Map<DBUser>(user);
            dbUser = _userDetailsRepository.UpdateUserDetails(dbUser);
            User UpdatedUser = _mapper.Map<User>(dbUser);
            return UpdatedUser;
        }
        public List<User> GetUsers()
        {
            List<DBUser> dbUsers = _userDetailsRepository.GetUsers();
            List<User> users = _mapper.Map<List<User>>(dbUsers);
            return users;
        }
        public User GetUserByUserId(string id)
        {
          DBUser dBUser = _userDetailsRepository.GetUserById(id);
            User user = _mapper.Map<User>(dBUser);
            return user;
        }
    }
}
