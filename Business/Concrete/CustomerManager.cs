using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int customerId)
        {
            return _customerDal.Get(c => c.CustomerId == customerId);
        }
    }
}