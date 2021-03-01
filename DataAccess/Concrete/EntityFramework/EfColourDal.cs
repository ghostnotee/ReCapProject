using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColourDal : EfEntityRepositoryBase<Colour, CarRentalCompanyContext>, IColourDal
    {

    }
}