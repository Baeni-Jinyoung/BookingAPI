using BookingAPI.Models;
using BookingAPI.Interfaces;
using BookingAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookingRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Name) || !TimeSpan.TryParse(request.BookingTime, out TimeSpan bookingTime))
            {
                return BadRequest("Invalid request");
            }

            if (bookingTime < new TimeSpan(9, 0, 0) || bookingTime > new TimeSpan(16, 0, 0))
            {
                return BadRequest("Invalid booking time");
            }

            Booking booking = new Booking
            {
                Name = request.Name,
                BookingTime = bookingTime
            };

            try
            {
                bool isCreated = _bookingService.CreateBooking(booking);

                if (isCreated)
                {
                    return Ok(new { BookingId = booking.BookingId });
                }
                else
                {
                    return Conflict("Booking already exists");
                }
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }

    public class BookingRequest
    {
        public string BookingTime { get; set; }
        public string Name { get; set; }
    }
}
