using BookShop.Models;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ParsonApi.Repositories;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ICRUDRepository<User> _crudRepository;
        public UserController(ICRUDRepository<User> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Responce<User>>> GetUsers(int page)
        {
            return (await _crudRepository.GetEntitiesAsync(page));
        }
    }
}
