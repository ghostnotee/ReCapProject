using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Fundamentals.Utilities.Results;

namespace Business.Concrete
{
    public class ColourManager : IColourService
    {
        IColourDal _colourDal;

        public ColourManager(IColourDal colourDal)
        {
            _colourDal = colourDal;
        }

        public IResult Add(Colour colour)
        {
            _colourDal.Add(colour);
            return new SuccessResult(Messages.EntityAdded);
        }

        public IResult Delete(Colour colour)
        {
            _colourDal.Delete(colour);
            return new SuccessResult(Messages.EntityDeleted);
        }

        public IDataResult<List<Colour>> GetAll()
        {
            return new SuccessDataResult<List<Colour>>(_colourDal.GetAll(), Messages.EntitiesListed);
        }

        public IDataResult<Colour> GetById(int colourId)
        {
            return new SuccessDataResult<Colour>(_colourDal.Get(c => c.ColourId == colourId), Messages.EntitiesListed);
        }

        public IResult Update(Colour colour)
        {
            _colourDal.Update(colour);
            return new SuccessResult(Messages.EntityUpdated);
        }
    }
}