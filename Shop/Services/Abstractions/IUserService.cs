using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Dtos;

namespace Shop.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDto>> GetBirthdayMen(DateTime date);

        Task<List<UserDto>> GetLastBuyers(uint days);

        Task<List<ProductCategoryDto>> GetUserCategories(int userId);
    }
}