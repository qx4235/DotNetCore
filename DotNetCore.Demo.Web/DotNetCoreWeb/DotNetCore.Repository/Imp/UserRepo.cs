using System;
using DotNetCore.Repository.Interface;

namespace DotNetCore.Repository.Imp
{
    public class UserRepo:IUserRepo
    {

        public string GetUserName()
        {
            return new Random().Next(1, 10000000).GetHashCode().ToString();
        }
    }
}