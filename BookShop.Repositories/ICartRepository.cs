using BookShop.Models;
using BookShop.Models.ViewModels;

namespace BookShop.Repositories
{
    public interface ICartRepository
    {
        string Message { get; set; }
        Task<Responce<Cart>> GetCartsWithJoinAsync(int page);
    }
}
