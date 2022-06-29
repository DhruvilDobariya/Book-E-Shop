using BookShop.Models.Data;
using BookShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Repositories.Services
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : class
    {
        public string Message { get; set; }

        private readonly BookShopDbContext _bookShopDbContext;
        private readonly DbSet<T> _entities;

        public CRUDRepository(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
            _entities = _bookShopDbContext.Set<T>();
        }

        public async Task<Responce<T>> GetEntitiesAsync(int page)
        {
            try
            {
                var pagesResults = 10f;
                var pagesCount = Math.Ceiling(_entities.Count() / pagesResults);

                var entities = await _entities.Skip((page - 1) * (int)pagesResults).Take((int)pagesResults).ToListAsync();

                if (entities.Count == 0)
                {
                    Message = "No entities found";
                }

                var response = new Responce<T>
                {
                    values = entities,
                    CurruntPage = page,
                    Pages = (int)pagesCount
                };

                return response;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Message = "Invalid Id";
                    return null;
                }
                T entity = await _entities.FindAsync(id);
                if (entity == null)
                {
                    Message = "Parson not found";
                }
                return entity;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }

        }

        public async Task<bool> AddEntityAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    Message = "Entity is null";
                    return false;
                }
                await _entities.AddAsync(entity);
                await _bookShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }

        }

        public async Task<bool> UpdateEntityAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    Message = "Entity is null";
                    return false;
                }
                _entities.Update(entity);
                await _bookShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }

        }

        public async Task<bool> DeleteEntityAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    Message = "Invalid Id";
                    return false;
                }
                T entity = await _entities.FindAsync(id);
                if (entity == null)
                {
                    Message = "Parson not found";
                    return false;
                }
                _entities.Remove(entity);
                await _bookShopDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return false;
            }

        }

        public int Count()
        {
            return _entities.Count();
        }

    }
}
