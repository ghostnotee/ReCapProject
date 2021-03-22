using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Fundamentals.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalCompanyContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on r.CarId equals c.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join ctmr in context.Customers on r.CustomerId equals ctmr.CustomerId
                             join u in context.Users on ctmr.UserId equals u.Id

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarModelBrandName = $"{c.CarModelName} {b.BrandName}",
                                 CustomerName=ctmr.CompanyName,
                                 CustomerFullName = $"{u.FirstName} {u.LastName}",
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}