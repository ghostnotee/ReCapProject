using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColourDal : IColourDal
    {
        public void Add(Colour entity)
        {
            using (CarRentalCompanyContext context = new CarRentalCompanyContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
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