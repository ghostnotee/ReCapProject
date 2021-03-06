using System.Collections.Generic;
using Entities.Concrete;
using Fundamentals.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);
        IResult Add(IFormFile file, CarImage carImageId);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetByCarId(int carId);
    }
}