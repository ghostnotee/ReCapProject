using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var result = rentalManager.Add(new Rental {
               CarId=1,
               CustomerId=1,
               RentDate= new DateTime(2021,2,7),
           });

           Console.WriteLine(result.Message);




           
           // CarDetailsSample();
        }

        private static void CarDetailsSample()
        {
            Console.WriteLine("Arabalar : Marka ----- Model ----- Renk ----- Günlük Fiyat -----Açıklama");

            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(" **** : {0} ----- {1} ----- {2} ----- {3}    {4}",
                    car.CarBrandName, car.CarModelName, car.CarColourName, car.DailyPrice, car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
