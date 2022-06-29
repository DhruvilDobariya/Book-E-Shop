using BookShop.Models;
using BookShop.Models.ViewModels;

namespace BookShop.Repositories
{
    public interface IUserRepository
    {
        string Message { get; set; }
        User Validate(string email, string password);
        Responce<User> GetUsersWithJoin(int page);
    }
}
