using Fundamentals.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string CarModelName { get; set; }
        public string CarBrandName { get; set; }
        public string CarColourName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}