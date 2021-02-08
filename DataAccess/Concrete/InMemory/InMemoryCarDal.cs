using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{CarId=1,BrandId=1,ColourId=1,DailyPrice=250,ModelYear=new DateTime(2017,01,01),Description="Araç hakkında bir takım bilgiler."},
                new Car{CarId=2,BrandId=1,ColourId=2,DailyPrice=300,ModelYear=new DateTime(2020,01,01),Description="Araç çok acayip manyak bir şey."},
                new Car{CarId=3,BrandId=2,ColourId=3,DailyPrice=400,ModelYear=new DateTime(2019,01,01),Description="Araç resmen yürüyen Uçak !!!"},
                new Car{CarId=4,BrandId=2,ColourId=2,DailyPrice=500,ModelYear=new DateTime(2015,01,01),Description="Araç öle böle değil yani !"},
                new Car{CarId=5,BrandId=3,ColourId=4,DailyPrice=1000,ModelYear=new DateTime(2021,01,01),Description="Araç bilgisi saymakla bitmez."},
                new Car{CarId=6,BrandId=4,ColourId=3,DailyPrice=550,ModelYear=new DateTime(2012,01,01),Description="Araç hakkında daha ne söylenebilir bilemiyorum."},
            };
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}