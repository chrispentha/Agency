using AgencyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetAppointmentsForDay(DateTime date)
        {
            var appointments = await _appointmentService.GetAppointmentsForDay(date);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromBody] string customerName)
        {
            var token = await _appointmentService.BookAppointment(customerName);
            return Ok(new { Token = token });
        }

        [HttpGet("offdays")]
        public async Task<IActionResult> GetOffDays()
        {
            var offDays = await _appointmentService.GetOffDays();
            return Ok(offDays);
        }

        [HttpPost("offdays")]
        public async Task<IActionResult> AddOffDay([FromBody] DateTime date)
        {
            await _appointmentService.AddOffDay(date);
            return Ok();
        }
    }
}