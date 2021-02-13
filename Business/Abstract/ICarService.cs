using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColourId(int colourId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}