using FribergsABData.Models;

namespace FribergsABData.Data
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(User user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            applicationDbContext?.Users.Remove(user);
            applicationDbContext?.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return applicationDbContext.Users.OrderBy(x => x.Name);
        }

        public User GetById(int id)
        {
            return applicationDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }
    }
}
