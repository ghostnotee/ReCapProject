using Fundamentals.Entities;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTcIn { get; set; }
        public string CustomerAddress { get; set; }
    }
}