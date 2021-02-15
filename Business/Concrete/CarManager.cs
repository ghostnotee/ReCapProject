using System;
using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarModelName.Length < 2)
            {
                return new ErrorDataResult<Car>(Messages.EntityModelNameInvalid);
            }
            return new SuccessDataResult<Car>(Messages.EntityAdded);
        }

        public IResult Delete(Car car)
        {
            return new SuccessDataResult<Car>(Messages.EntityDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.EntitiesListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.EntitiesListed);
        }

        public IDataResult<List<Car>> GetCarsByColourId(int colourId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColourId == colourId), Messages.EntitiesListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessDataResult<Car>(Messages.EntityUpdated);
        }
    }
}