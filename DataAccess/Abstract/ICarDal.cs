using Entities.Concrete;
using Fundamentals.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}