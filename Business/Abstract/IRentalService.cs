using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.Utilities.Results;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetail(int rentalId);
        IResult AddTransactionTest(Rental rental);
    }
}