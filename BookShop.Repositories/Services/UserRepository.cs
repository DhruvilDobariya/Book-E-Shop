using BookShop.Models;
using BookShop.Models.Data;
using BookShop.Models.ViewModels;

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

        public Responce<User> GetUsersWithJoin(int page)
        {
            try
            {
                var pagesResults = 10f;
                var pagesCount = Math.Ceiling(_bookShopDbContext.User.Count() / pagesResults);

                IEnumerable<User> query = from User in _bookShopDbContext.User.Skip((page - 1) * (int)pagesResults).Take((int)pagesResults)
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

                List<User> users = new List<User>();

                foreach (var item in query)
                {
                    users.Add(item);
                }

                var response = new Responce<User>
                {
                    values = users,
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
