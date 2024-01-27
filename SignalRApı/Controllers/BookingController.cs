using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Services;
using SignalR.DtoLayer.Dto.AboutDto;
using SignalR.DtoLayer.Dto.BookingDto;
using SignR.Entitylayer.Entites;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var bookingList = bookingService.GetAll();
            return Ok(bookingList);
        }

        [HttpGet("{id}")]
        public IActionResult getBookingDetails(int id)
        {
            var bookingDetails = bookingService.GetById(id);
            return Ok(bookingDetails);
        }


        [HttpPost]
        public IActionResult addBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
               Date = createBookingDto.Date,
               Mail = createBookingDto.Mail,
               Name = createBookingDto.Name,
               PersonCount = createBookingDto.PersonCount,
               Phone = createBookingDto.Phone
            };
            bookingService.Add(booking);
            return Ok("Rezervasyon başarılı bir şekilde oluştu");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Date = updateBookingDto.Date,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone
            };

            bookingService.Update(booking);
            return Ok("Rezervayon başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var find = bookingService.GetById(id);
            bookingService.Remove(find);
            return Ok("Rezervasyon başarıyla silindi");
        }
    }
}
