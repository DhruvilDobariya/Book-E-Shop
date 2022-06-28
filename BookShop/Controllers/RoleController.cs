using BookShop.Models;
using BookShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ParsonApi.Repositories;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly ICRUDRepository<Role> _crudRepository;
        public RoleController(ICRUDRepository<Role> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<User>> GetRoles(int page)
        {
            return Ok(await _crudRepository.GetEntitiesAsync(page));
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult<Responce<Role>>> GetRole(int id)
        {
            return Ok(await _crudRepository.GetEntityByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddUser(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.AddEntityAsync(role))
            {
                return Ok(role);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpPut]
        public async Task<ActionResult<Role>> UpdateUser(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.UpdateEntityAsync(role))
            {
                return Ok(role);
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
                return Ok("Role deleted successfully");
            }
            return BadRequest(_crudRepository.Message);
        }
    }
}
