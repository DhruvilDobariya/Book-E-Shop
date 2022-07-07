using BookShop.Models;
using BookShop.Models.ViewModels;

namespace BookShop.Repositories
{
    public interface IUserRepository
    {
        string Message { get; set; }
        User Validate(string email, string password);
        Task<Responce<User>> GetUsersWithJoinAsync(int page, int count, string keyword);
    }
}
