using System;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public short BrandId { get; set; }
        public short ColorId { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}