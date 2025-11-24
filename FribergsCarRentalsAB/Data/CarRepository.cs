using FribergsCarRentalsAB.Models;

namespace FribergsCarRentalsAB.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public void Add(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            applicationDbContext.Cars.Remove(car);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Rentable).OrderByDescending(x => x.Brand);
        }
        public IEnumerable<Car> GetRentebleCars()
        {
            
            return applicationDbContext.Cars.Where(x => x.Rentable).OrderByDescending(x=>x.Brand);
        }

        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Car car)
        {
            applicationDbContext.Cars.Update(car);
            applicationDbContext.SaveChanges();
        }
    }
}
