using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Shop.Repositories.Abstractions;

namespace Shop.Repositories.Impl
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext DbContext { get; }

        public UserRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Task<List<User>> GetBirthdayUsers(DateTime date)
            => DbContext.Users
                .Include(x => x.Purchases)
                .Where(x => x.BirthDate == date)
                .ToListAsync();

        public Task<List<User>> GetLastBuyers(uint days)
            => DbContext.Users
                .Include(x => x.Purchases)
                .Where(x => x.Purchases.Any(y => y.PurchaseDate.AddDays(days) >= DateTime.Now))
                .ToListAsync();

        public Task<User> GetUserById(int userId)
            => DbContext.Users
                .Include(x => x.Purchases)
                .ThenInclude(x => x.PurchaseItems)
                .ThenInclude(x => x.ShopItem)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.UserId == userId);
    }
}