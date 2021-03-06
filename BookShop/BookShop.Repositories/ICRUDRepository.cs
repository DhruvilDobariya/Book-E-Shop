using BookShop.Models.ViewModels;

namespace BookShop.Repositories
{
    public interface ICRUDRepository<T> where T : class
    {
        string Message { get; set; }
        Task<Responce<T>> GetEntitiesAsync(int page, int count, string keyword);
        Task<T> GetEntityByIdAsync(int id);
        Task<bool> AddEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<bool> DeleteEntityAsync(int id);
        int Count();
    }
}