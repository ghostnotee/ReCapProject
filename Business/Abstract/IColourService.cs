using System.Collections.Generic;
using Entities.Concrete;
using Fundamentals.Utilities.Results;

namespace Business.Abstract
{
    public interface IColourService
    {
        IDataResult<List<Colour>> GetAll();
        IDataResult<Colour> GetById(int colourId);
        IResult Add(Colour colour);
        IResult Update(Colour colour);
        IResult Delete(Colour colour);
    }
}