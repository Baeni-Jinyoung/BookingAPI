using System;
namespace BookingAPI.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public string Name { get; set; }
        public TimeSpan BookingTime { get; set; }
    }
}
