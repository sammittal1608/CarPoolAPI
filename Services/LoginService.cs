using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.DBModels;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoginService:ILoginService
    {
        private readonly AppDbContext dbContext;
        IUserDetailsRepository _userRepository;
        IMapper _mapper;


        public LoginService(AppDbContext dbContext,IUserDetailsRepository userRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
           _userRepository= userRepository;
            _mapper = mapper;
        }
        public string GetNameByEmail(string email)
        {
            var parts = email.Split("@");

            if (parts.Length >= 2)
            {
                
                var username = parts[0];

                
                return username;
            }
            return "";
        }

        public User Register(Credentials signUp)
        {
           var existingUser =  _userRepository.GetUserByEmail(signUp.Email);
            if (existingUser != null)
            {
                return null;
            }
            var newUser = new User
            {
                Email = signUp.Email,
                Password = signUp.Password,
                FirstName = GetNameByEmail(signUp.Email)
            };
            DBUser dbUser = _mapper.Map<DBUser>(newUser);
            dbUser =  _userRepository.AddUser(dbUser);
            User addedUser = _mapper.Map<User>(dbUser);
            return addedUser;
        }
        public User SignIn(Credentials signin)
        {
            DBUser dbUser = _userRepository.GetUserByEmail(signin.Email);
            User user = _mapper.Map<User>(dbUser);

            if (user == null)
            {
                return null;
            }
            //if (!PasswordHasher.VerifyPassword(model.Password, user.PasswordHash))
            //{
            //    return AuthResult.Failure("Invalid credentials");
            //}
            return user;
           
        }
    }
}
