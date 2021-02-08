using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalCompanyContext>, IBrandDal
    {

    }
}