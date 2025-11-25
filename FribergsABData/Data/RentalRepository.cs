using FribergsABData.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsABData.Data
{
    public class RentalRepository:IRental
    {
         
        private readonly ApplicationDbContext applicationDbContext;

        public RentalRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }


        public void Add(Rental rental)
        {
           
            applicationDbContext.Rentals.Add(rental);
            
            var carRentable = applicationDbContext.Cars.Find(rental.CarId);
            if (carRentable.Rentable != null)
            {
                if (carRentable != null)
                {
                    carRentable.Rentable = false;
                }
            }
            applicationDbContext.SaveChanges();
            }
        

        public void Delete(Rental rental)
        {
            rental = applicationDbContext.Rentals.Find(rental.Id);
            if (rental != null)
            {
                var carRentable = applicationDbContext.Cars.Find(rental.CarId);
                if (carRentable != null)
                {
                    carRentable.Rentable = true;

                }
                applicationDbContext.Rentals.Remove(rental);
            }

            applicationDbContext.Remove(rental);
            applicationDbContext.SaveChanges();
        }

        public IEnumerable<Car> GetAllCars()
        {

            return applicationDbContext.Cars.OrderBy(x => x.Brand);
        }

        public IEnumerable<Car> GetAllRentals()
        {
            //return applicationDbContext.Rentals.Include(x => x.Car).OrderByDescending(x => x.Car.Id);
           return applicationDbContext.Cars.OrderByDescending(x => x.Id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return applicationDbContext.Users.OrderByDescending(x=>x.Name);
        }

        public Rental GetById(int id)
        {
            return applicationDbContext.Rentals.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Car> GetRentebleCars()
        {
            return applicationDbContext.Cars.OrderByDescending(x => x.Name);
        }

        public void Update(Rental rental)
        {
            applicationDbContext.Update(rental);
            applicationDbContext.SaveChanges();
        }
    }
}
