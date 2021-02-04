using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Colour{ColourId=1,ColourName="Siyah"},
                new Colour{ColourId=2,ColourName="Kırmızı"},
                new Colour{ColourId=3,ColourName="Mavi"},
                new Colour{ColourId=4,ColourName="Yeşil"},
                new Colour{ColourId=5,ColourName="Beyaz"},
                new Colour{ColourId=6,ColourName="Gri"}
            };
        }

        public void Add(Colour entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Colour entity)
        {
            throw new NotImplementedException();
        }

        public Colour Get(Expression<Func<Colour, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Colour entity)
        {
            throw new NotImplementedException();
        }
    }
}