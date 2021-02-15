using System.Collections.Generic;
using Entities.Concrete;
using Fundamentals.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetByUserName(string name);
    }
}