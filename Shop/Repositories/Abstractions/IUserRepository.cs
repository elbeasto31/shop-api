using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataBase.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<List<User>> GetBirthdayUsers(DateTime date);
        Task<List<User>> GetLastBuyers(uint days);
        Task<User> GetUserById(int userId);
    }
}