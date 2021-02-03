using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>{
                new Brand{BrandId=1,BrandName="Alfa Romeo"},
                new Brand{BrandId=2,BrandName="Anadol"},
                new Brand{BrandId=4,BrandName="Volkswagen"},
                new Brand{BrandId=5,BrandName="Volvo"},
                new Brand{BrandId=6,BrandName="Fiat"},
            };
        }
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(bTD => bTD.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int id)
        {
            return _brands.SingleOrDefault(b => b.BrandId == id);
        }

        public void Update(Brand brand)
        {
            Brand updateToBrand = _brands.SingleOrDefault(uTB => uTB.BrandId == brand.BrandId);
            updateToBrand.BrandName = brand.BrandName;
        }
    }
}