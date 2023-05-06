using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Constants;
using Shop.Filters.Exception;
using Shop.Services.Abstractions;

namespace Shop.Controllers
{
    [ApiController]
    [Route(ApiRouteConstants.UserApiRoute)]
    public class UserController : Controller
    {
        private IUserService UserService { get; }
        
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [Route(ApiRouteConstants.BirthdayMenRoute)]
        public async Task<IActionResult> GetBirthdayUsers([FromRoute] DateTime date)
            => Ok(await UserService.GetBirthdayMen(date));
        
        [Route(ApiRouteConstants.LastBuyersRoute)]
        public async Task<IActionResult> GetLastBuyers([FromRoute] uint days)
            => Ok(await UserService.GetLastBuyers(days));
        
        [Route(ApiRouteConstants.UserCategoriesRoute)]
        [NotFoundException]
        public async Task<IActionResult> GetUserCategories([FromRoute] int id)
            => Ok(await UserService.GetUserCategories(id));
    }
}