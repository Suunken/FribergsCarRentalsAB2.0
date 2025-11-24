using FribergsCarRentalsAB.Models;

namespace FribergsCarRentalsAB.Data
{
    public interface IRental
    {
        Rental GetById(int id);
        IEnumerable<Car> GetAllCars();
        IEnumerable<Rental> GetAllRentals();
        IEnumerable<User> GetAllUsers();
        IEnumerable<Car> GetRentebleCars();


        void Add(Rental model);
        void Update(Rental model);
        void Delete(Rental model);

    }
}
