using System;
using DotNetCore.Repository.Interface;
using DotNetCore.Service.Interface;

namespace DotNetCore.Service.Imp
{
    public class UserService:IUserService
    {
//        private readonly IUserRepo _userRepo;
//
//        public UserService(IUserRepo userRepo)
//        {
//            _userRepo = userRepo;
//        }

        public string GetUserName()
        {
//            return _userRepo.GetUserName();
            return "abc";
        }

        public string GetRandom()
        {
            return new Random().Next(1, 10000000).GetHashCode().ToString();
        }


    }
}