using FribergsCarRentalsAB.Models;

namespace FribergsCarRentalsAB.Data
{
    public interface ICar
    {
        Car GetById(int id);

        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetRentebleCars();
        void Add(Car model);
        void Update(Car model);
        void Delete(Car model);

    }
}
