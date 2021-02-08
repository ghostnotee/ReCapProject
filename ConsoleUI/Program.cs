using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Arabalar : Marka ----- Model ----- Renk ----- Günlük Fiyat -----Açıklama");

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(" **** : {0} ----- {1} ----- {2} ----- {3}    {4}",
                car.CarBrandName, car.CarModelName, car.CarColourName, car.DailyPrice, car.Description);
            }
        }
    }
}
