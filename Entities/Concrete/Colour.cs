using Fundamentals.Entities;

namespace Entities.Concrete
{
    public class Colour : IEntity
    {
        public int ColourId { get; set; }
        public string ColourName { get; set; }
    }
}