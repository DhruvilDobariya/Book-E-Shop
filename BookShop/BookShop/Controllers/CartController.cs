using BookShop.Models;
using BookShop.Models.ViewModels;
using BookShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICRUDRepository<Cart> _crudRepository;
        private readonly ICartRepository _cartRepository;
        public CartController(ICRUDRepository<Cart> crudRepository, ICartRepository cartRepository)
        {
            _crudRepository = crudRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<Responce<Cart>>> GetCarts(int page = 1)
        {
            return Ok(await _cartRepository.GetCartsWithJoinAsync(page));
        }

        [HttpGet]
        [Route("list/{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            return Ok(await _crudRepository.GetEntityByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> AddCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.AddEntityAsync(cart))
            {
                return Ok(cart);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpPut]
        public async Task<ActionResult<Cart>> UpdateCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Json(ModelState));
            }
            if (await _crudRepository.UpdateEntityAsync(cart))
            {
                return Ok(cart);
            }
            return BadRequest(_crudRepository.Message);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCart(int id)
        {
            if (id <= 0)
            {
                return BadRequest(Json("Invalid Id"));
            }
            if (await _crudRepository.DeleteEntityAsync(id))
            {
                return Ok("cart deleted successfully");
            }
            return BadRequest(_crudRepository.Message);
        }
    }
}
