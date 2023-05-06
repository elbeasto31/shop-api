using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Entities;
using Shop.Dtos;
using Shop.Exceptions;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractions;
using Shop.Utils.Extensions;

namespace Shop.Services.Impl
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        
        public async Task<List<UserDto>> GetBirthdayMen(DateTime date)
        {
            var users = await UserRepository.GetBirthdayUsers(date);

            return users.Select(MapUserDto).ToList();
        }        
        
        public async Task<List<UserDto>> GetLastBuyers(uint days)
        {
            var users = await UserRepository.GetLastBuyers(days);

            return users.Select(MapUserDto).ToList();
        }
        
        public async Task<List<ProductCategoryDto>> GetUserCategories(int userId)
        {
            var user = await UserRepository.GetUserById(userId);

            if (user is null)
                throw new NotFoundException($"User with {userId} id not found", userId);
            
            var categories = user.Purchases
                .SelectMany(x => x.PurchaseItems.Select(y => y.ShopItem.Category))
                .DistinctBy(x => x.ProductCategoryId)
                .ToList();

            return categories.Select(y => new ProductCategoryDto()
            {
                Id = y.ProductCategoryId,
                Name = y.Name,
                NumberOfPurchasedItems = user.Purchases
                    .SelectMany(x => x.PurchaseItems)
                    .Count(x => x.ShopItem.Category.ProductCategoryId == y.ProductCategoryId)
            }).ToList();
        }
        
        // TODO: Connect Mapster for automatic mapping
        private UserDto MapUserDto(User user)
            => new()
            {
                Id = user.UserId,
                FullName = user.FullName,
                BirthDate = user.BirthDate,
                LastPurchaseDate = user.Purchases.Any() ? user.Purchases.Max(x => x.PurchaseDate) : null,
                RegistrationDate = user.RegistrationDate
            };
    }
}