using Entities.Concrete;
using Fundamentals.DataAccess;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {

    }
}