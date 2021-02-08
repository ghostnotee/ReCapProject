using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}