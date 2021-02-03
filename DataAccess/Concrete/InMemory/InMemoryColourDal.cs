using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColourDal : IColourDal
    {
        List<Colour> _colours;
        public InMemoryColourDal()
        {
            _colours = new List<Colour>{
                new Colour{ColorId=1,ColorName="Siyah"},
                new Colour{ColorId=2,ColorName="Kırmızı"},
                new Colour{ColorId=3,ColorName="Mavi"},
                new Colour{ColorId=4,ColorName="Yeşil"},
                new Colour{ColorId=5,ColorName="Beyaz"},
                new Colour{ColorId=6,ColorName="Gri"}
            };
        }

        public void Add(Colour colour)
        {
            _colours.Add(colour);
        }

        public void Delete(Colour colour)
        {
            Colour colourToDelete = _colours.SingleOrDefault(cTD => cTD.ColorId == colour.ColorId);
            _colours.Remove(colourToDelete);
        }

        public List<Colour> GetAll()
        {
            return _colours;
        }

        public Colour GetById(int id)
        {
            return _colours.SingleOrDefault(c => c.ColorId == id);
        }

        public void Update(Colour colour)
        {
            Colour colourToUpdate = _colours.SingleOrDefault(cTU => cTU.ColorId == colour.ColorId);
            colourToUpdate.ColorName = colour.ColorName;
        }
    }
}