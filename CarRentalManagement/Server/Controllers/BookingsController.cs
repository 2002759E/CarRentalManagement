using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public BookingsController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> GetBookings()
        {

            var bookings = await _unitOfWork.Bookings.GetAll(includes: q => q.Include(x =>
x.Vehicle).Include(x => x.Customer));
            return Ok(bookings);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetBooking(int id)
        {

            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.Id)
            {
                return BadRequest();
            }


            _unitOfWork.Bookings.Update(booking);

            try
            {

                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!await BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {

            await _unitOfWork.Bookings.Insert(booking);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {

            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            if (booking == null)
            {
                return NotFound();
            }


            await _unitOfWork.Bookings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }


        private async Task<bool> BookingExists(int id)
        {

            var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
            return booking != null;
        }
    }
}
