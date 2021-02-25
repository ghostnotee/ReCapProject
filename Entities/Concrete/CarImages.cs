using System;
using Fundamentals.Entities;

namespace Entities.Concrete
{
    public class CarImages : IEntity
    {
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}