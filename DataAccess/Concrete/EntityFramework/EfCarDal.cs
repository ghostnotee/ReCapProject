using System.Linq;
using System.Collections.Generic;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.DataAccess.EntityFramework;
using System.Linq.Expressions;
using System;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalCompanyContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colours on c.ColourId equals clr.ColourId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarModelName = c.CarModelName,
                                 CarBrandName = b.BrandName,
                                 CarColourName = clr.ColourName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                             };
                return result.ToList();
            }
        }
    }
}