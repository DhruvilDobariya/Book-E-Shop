using BookShop.Models;
using BookShop.Models.Data;
using BookShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Repositories.Services
{
    public class UserRepository : IUserRepository
    {
        public string Message { get; set; }

        private readonly BookShopDbContext _bookShopDbContext;

        public UserRepository(BookShopDbContext bookShopDbContext)
        {
            _bookShopDbContext = bookShopDbContext;
        }

        public User Validate(string email, string password)
        {
            try
            {
                //user = _bookShopDbContext.User.Where(user => user.Email == email && user.Password == password).FirstOrDefault();
                var query = (from User in _bookShopDbContext.User.Where(user => user.Email == email && user.Password == password)
                             join Role in _bookShopDbContext.Role on User.Roleid equals Role.Id
                             select new User
                             {
                                 Id = User.Id,
                                 Firstname = User.Firstname,
                                 Lastname = User.Lastname,
                                 Email = User.Email,
                                 Password = User.Password,
                                 Roleid = User.Roleid,
                                 Role = Role
                             }).ToList().FirstOrDefault();

                if (query == null)
                {
                    Message = "User Not Found";
                    return null;
                }
                return query;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return null;
            }
        }

        public async Task<Responce<User>> GetUsersWithJoinAsync(int page, int count, string keyword)
        {
            try
            {
                var pagesResults = 10f;
                var pagesCount = Math.Ceiling(_bookShopDbContext.User.Where(c => keyword == null || c.Firstname.ToLower().Contains(keyword) || c.Lastname.ToLower().Contains(keyword)).Count() / pagesResults);

                var query = from User in _bookShopDbContext.User.Where(c => keyword == null || c.Firstname.ToLower().Contains(keyword) || c.Lastname.ToLower().Contains(keyword)).Skip((page - 1) * (int)pagesResults).Take((int)pagesResults)
                                          join Role in _bookShopDbContext.Role on User.Roleid equals Role.Id
                                          select new User
                                          {
                                              Id = User.Id,
                                              Firstname = User.Firstname,
                                              Lastname = User.Lastname,
                                              Email = User.Email,
                                              Password = User.Password,
                                              Roleid = User.Id,
                                              Role = Role
                                          };

                

                var response = new Responce<User>
                {
                    values = await query.ToListAsync(),
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
    }
}
