using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int carId);
        IResult Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColourId(int colourId);
        List<CarDetailDto> GetCarDetails();
    }
}