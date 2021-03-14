using System.Collections.Generic;
using Fundamentals.Entities.Concrete;

namespace Fundamentals.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}