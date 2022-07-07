using BookShop.Models;
using BookShop.Models.ViewModels;
using BookShop.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ICRUDRepository<User> _crudRepository;
        private readonly IUserRepository _userRepository;
        public UserController(ICRUDRepository<User> crudRepository, IUserRepository userRepository)
        {
            _crudRepository = crudRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Responce<User>>> GetUsersAsync(int page = 1, int count = 5, string? keyword = "")
        {
            Responce<User> responce = await _userRepository.GetUsersWithJoinAsync(page, count, keyword);
            if (responce == null)
            {
                return BadRequest(_userRepository.Message);
            }
            return Ok(responce);
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await _crudRepository.GetEntityByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            if (!ModelState.IsValid)
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
            if (id <= 0)
            {
                return BadRequest(Json("Invalid Id"));
            }
            if (await _crudRepository.DeleteEntityAsync(id))
            {
                return Ok("User deleted successfully");
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult<User> LoginUser(string eamil, string password)
        {
            User user = _userRepository.Validate(eamil, password);
            if (user == null)
            {
                return NotFound(_userRepository.Message);
            }
            return user;
        }
    }
}
