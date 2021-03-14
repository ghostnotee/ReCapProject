using System.Collections.Generic;
using Entities.Concrete;
using Fundamentals.DataAccess;
using Fundamentals.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}