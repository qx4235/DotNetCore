using System;
using DotNetCore.Repository.Interface;

namespace DotNetCore.Repository.Imp
{
    public class UserRepo:IUserRepo
    {
        private readonly int _rndNum = new Random().Next(100000000);
        public string GetUserName()
        {
            return $"repo:{_rndNum}";
        }
    }
}