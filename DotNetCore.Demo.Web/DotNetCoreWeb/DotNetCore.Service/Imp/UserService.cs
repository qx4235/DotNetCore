using System;
using DotNetCore.Repository.Interface;
using DotNetCore.Service.Interface;

namespace DotNetCore.Service.Imp
{
    public class UserService:IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
private readonly int _rndNum=new Random().Next(100000000);

//        public IUserRepo UserRepo { get; set; }

        public string GetUserName()
        {
                        return _userRepo.GetUserName();
//            return "abc";
        }

        public string GetRandom()
        {
            return $"userService:{_rndNum}";
        }


    }
}