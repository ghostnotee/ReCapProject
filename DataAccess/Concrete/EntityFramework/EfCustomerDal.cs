using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalCompanyContext>, ICustomerDal
    {

    }
}