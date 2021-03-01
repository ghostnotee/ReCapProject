using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.Aspects.Autofac.Validation;
using Fundamentals.Utilities.Business;
using Fundamentals.Utilities.Helpers;
using Fundamentals.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileStorageHelper.UploadFile(file);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(IFormFile file, CarImage carImage)
        {
            FileStorageHelper.DeleteFile(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.EntitiesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId), Messages.EntitiesListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileStorageHelper.UpdateFile(_carImageDal.Get
                                    (i => i.CarImageId == carImage.CarImageId).ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult CheckIfCarImageLimit(int carId)
        {
            int numberOfPhotos = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (numberOfPhotos >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = @"/WebAPI/Storage/CarImages/defaultImage.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }
    }
}