using System.Linq;
using System.Collections.Generic;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalCompanyContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join clr in context.Colours on c.ColourId equals clr.ColourId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarModelName = c.CarModelName,
                                 CarBrandName = b.BrandName,
                                 CarColourName = clr.ColourName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}