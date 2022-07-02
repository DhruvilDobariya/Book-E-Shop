using BookShop.Models;
using BookShop.Models.Data;
using BookShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Repositories.Services
{
    public class CartRepository : ICartRepository
    {
        public string Message { get; set; }

        private readonly BookShopDbContext _bookShopDbContext;

        public CartRepository(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
        }

        public async Task<Responce<Cart>> GetCartsWithJoinAsync(int page)
        {
            var pagesResults = 10f;



            var query = _bookShopDbContext.Cart.Skip((page - 1) * (int)pagesResults).Take((int)pagesResults).Include(c => c.Book).AsQueryable();

            if (query == null)
            {
                Message = "No entities found";
            }

            var response = new Responce<Cart>
            {
                values = await query.ToListAsync(),
                CurruntPage = page,
                Pages = (int)(Math.Ceiling(_bookShopDbContext.Cart.Count() / 10f))
            };

            return response;
        }

        public Task<Responce<Cart>> GetCartsWithJoin(int page)
        {
            throw new NotImplementedException();
        }
    }
}
