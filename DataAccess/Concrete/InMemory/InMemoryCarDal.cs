using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=250,ModelYear=new DateTime(2017,01,01),Description="Araç hakkında bir takım bilgiler."},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=300,ModelYear=new DateTime(2020,01,01),Description="Araç çok acayip manyak bir şey."},
                new Car{CarId=3,BrandId=2,ColorId=3,DailyPrice=400,ModelYear=new DateTime(2019,01,01),Description="Araç resmen yürüyen Uçak !!!"},
                new Car{CarId=4,BrandId=2,ColorId=2,DailyPrice=500,ModelYear=new DateTime(2015,01,01),Description="Araç öle böle değil yani !"},
                new Car{CarId=5,BrandId=3,ColorId=4,DailyPrice=1000,ModelYear=new DateTime(2021,01,01),Description="Araç bilgisi saymakla bitmez."},
                new Car{CarId=6,BrandId=4,ColorId=3,DailyPrice=550,ModelYear=new DateTime(2012,01,01),Description="Araç hakkında daha ne söylenebilir bilemiyorum."},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}