using BookingAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using BookingAPI.Interfaces;

namespace BookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly List<Booking> _bookings = new List<Booking>(); 
        private readonly TimeSpan BusinessStartTime = new TimeSpan(9, 0, 0);
        private readonly TimeSpan BusinessEndTime = new TimeSpan(17, 0, 0);
        private const int MAX_CAPACITY = 4;

        public bool CreateBooking(Booking booking)
        {
            if(string.IsNullOrEmpty(booking.Name) || booking.BookingTime < BusinessStartTime || booking.BookingTime >= BusinessEndTime)
            {
                throw new ArgumentException("Invalid booking");
            }

            int count = _bookings.Count(book => book.BookingTime == book.BookingTime);
            if(count >= MAX_CAPACITY)
            {
                return false;
            }

            booking.BookingId = Guid.NewGuid();
            _bookings.Add(booking);
            return true;
        }
    }
}
