using System;
using System.Collections.Generic;
using System.IO;
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
            IResult result = BusinessRules.Run(
                CheckCarImageLimit(carImage.CarId),
                HaveSupportedFileType(file.FileName),
                CheckImageFileLength(file.Length)
            );

            if (result != null) return result;

            var fileStorageSuccess = FileStorageHelper.UploadFile(file);
            if (!fileStorageSuccess.Success)
            {
                return new ErrorResult(Messages.FileUploadFailed);
            }

            carImage.ImagePath = fileStorageSuccess.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var result = FileStorageHelper.DeleteFile(_carImageDal.Get(i => i.CarImageId == carImage.CarImageId).ImagePath);

            if (!result.Success)
            {
                return new ErrorResult("Image file remove failed!");
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == carImageId), Messages.EntitiesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                string defaultImagePath = Path.Combine("/Storage", "Images", "default.jpg");

                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = carId, ImagePath = defaultImagePath });

                return new SuccessDataResult<List<CarImage>>(carImages, Messages.EntitiesListed);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.EntitiesListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                 HaveSupportedFileType(file.FileName),
                 CheckImageFileLength(file.Length)
             );

            if (result != null) return result;


            string currentImagePath = _carImageDal.Get(i => i.CarImageId == carImage.CarImageId).ImagePath;
            carImage.ImagePath = FileStorageHelper.UpdateFile(file, currentImagePath).Message;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.EntityAdded);
        }


        // Business Rules
        private IResult HaveSupportedFileType(string contentType)
        {
            string[] supportedFileTypes = { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(contentType).ToLower();
            bool result = supportedFileTypes.Contains(fileExtension);

            if (result == false)
            {
                return new ErrorResult("Please attach image file!");
            }
            return new SuccessResult();
        }

        private IResult CheckImageFileLength(long length)
        {
            if (length >= 1048576)
            {
                return new ErrorResult("File length must be less than 1 MB");
            }
            return new SuccessResult();
        }

        public IResult CheckCarImageLimit(int carId)
        {
            int numberOfPhotos = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (numberOfPhotos >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageNull(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (result)
            {
                return new SuccessResult("Photo found!");
            }

            return new ErrorResult("No photo found!");
        }
    }
}