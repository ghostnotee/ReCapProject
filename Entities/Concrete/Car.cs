using System;
using System.Collections.Generic;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public short BrandId { get; set; }
        public short ColourId { get; set; }
        public string CarModelName { get; set; }
        public DateTime ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Colour Colour { get; set; }
    }
}