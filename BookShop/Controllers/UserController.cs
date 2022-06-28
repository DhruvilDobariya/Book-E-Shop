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
        public async Task<ActionResult<User>> GetUsers(int page)
        {
            return Ok(await _crudRepository.GetEntitiesAsync(page));
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult<Responce<User>>> GetUser(int id)
        {
            return Ok(await _crudRepository.GetEntityByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.AddEntityAsync(user))
            {
                return Ok(user);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.UpdateEntityAsync(user))
            {
                return Ok(user);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if(id <= 0)
            {
                return BadRequest(Json("Invalid Id"));
            }
            if(await _crudRepository.DeleteEntityAsync(id))
            {
                return Ok(Json("User deleted successfully"));
            }
            return BadRequest(_crudRepository.Message);
        }
    }
}
