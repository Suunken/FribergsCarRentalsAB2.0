using FribergsCarRentalsAB.Models;

namespace FribergsCarRentalsAB.Data
{
    public interface IUser
    {
        User GetById(int id);
        IEnumerable<User> GetAllUsers();

        void Add(User user);
        void Update(User user);
        void Delete(User user);

    }
}
