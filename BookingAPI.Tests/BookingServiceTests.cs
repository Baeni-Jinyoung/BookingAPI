using BookingAPI.Models;
using BookingAPI.Services;
using Xunit;

namespace BookingApi.Tests
{
    public class BookingServiceTests
    {
        private readonly BookingService _bookingService;

        public BookingServiceTests()
        {
            _bookingService = new BookingService();
        }

        [Fact]
        public void CreateBooking_ShouldReturnTrue_WhenBookingIsValid()
        {
            // Arrange
            var booking = new Booking
            {
                Name = "Jinyoung Bae",
                BookingTime = new TimeSpan(10, 0, 0)
            };

            // Act
            var result = _bookingService.CreateBooking(booking);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CreateBooking_ShouldReturnFalse_WhenBookingTimeIsFull()
        {
            // Arrange
            var bookingTime = new TimeSpan(10, 0, 0);

            for (int i = 0; i < 4; i++)
            {
                _bookingService.CreateBooking(new Booking { Name = "Jinyoung Bae", BookingTime = bookingTime });
            }

            var newBooking = new Booking
            {
                Name = "Jinyoung Bae1",
                BookingTime = bookingTime
            };

            // Act
            var result = _bookingService.CreateBooking(newBooking);

            // Assert
            Assert.False(result);
        }
    }
}
