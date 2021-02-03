using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColourDal
    {
        List<Colour> GetAll();
        Colour GetById(int id);
        void Add(Colour colour);
        void Update(Colour colour);
        void Delete(Colour colour);
    }
}