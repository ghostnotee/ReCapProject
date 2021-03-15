using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.Aspects.Autofac.Performance;
using Fundamentals.Aspects.Autofac.Transaction;
using Fundamentals.Utilities.Results;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentalStatus = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (rentalStatus == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.EntityAdded);
            }

            return new ErrorResult(Messages.RentalError);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionTest(Rental rental)
        {
            Add(rental);
            if (rental.ReturnDate == null)
            {
                throw new Exception("");
            }
            Add(rental);
            return null;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.EntityDeleted);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId), Messages.EntitiesListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}