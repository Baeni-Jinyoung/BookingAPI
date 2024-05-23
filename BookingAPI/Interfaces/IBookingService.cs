using BookingAPI.Models;
namespace BookingAPI.Interfaces
{
    public interface IBookingService
    {
        bool CreateBooking(Booking booking);
    }
}
