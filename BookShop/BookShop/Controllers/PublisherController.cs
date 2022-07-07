using BookShop.Models;
using BookShop.Models.ViewModels;
using BookShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly ICRUDRepository<Publisher> _crudRepository;
        public PublisherController(ICRUDRepository<Publisher> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Responce<Publisher>>> GetPublishers(int page = 1, int count = 5, string? keyword = "")
        {
            return Ok(await _crudRepository.GetEntitiesAsync(page, count, keyword));
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult<Publisher>> GetPublisher(int id)
        {
            return Ok(await _crudRepository.GetEntityByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Publisher>> AddPublisher(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.AddEntityAsync(publisher))
            {
                return Ok(publisher);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpPut]
        public async Task<ActionResult<Publisher>> UpdatePublisher(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.UpdateEntityAsync(publisher))
            {
                return Ok(publisher);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeletePublisher(int id)
        {
            if (id <= 0)
            {
                return BadRequest(Json("Invalid Id"));
            }
            if (await _crudRepository.DeleteEntityAsync(id))
            {
                return Ok("publisher deleted successfully");
            }
            return BadRequest(_crudRepository.Message);
        }
    }
}
