using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.Utilities.Results;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), Messages.EntitiesListed);
        }

        public IDataResult<List<User>> GetByUserName(string name)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.FirstName.Contains(name) || u.LastName.Contains(name)), Messages.EntitiesListed);
        }

        public IResult Update(User user)
        {
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}