using BookShop.Models;
using BookShop.Models.ViewModels;
using BookShop.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Responce<Role>>> GetRoles(int page = 1, int count = 5, string? keyword = "")
        {
            return Ok(await _crudRepository.GetEntitiesAsync(page, count, keyword));
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            return Ok(await _crudRepository.GetEntityByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(Role role)
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
        public async Task<ActionResult<Role>> UpdateRole(Role role)
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
        public async Task<ActionResult> DeleteRole(int id)
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
