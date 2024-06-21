using AgencyAPI.Data;
using AgencyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgencyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAgencyRepository _agencyService;

        public AppointmentsController(IAgencyRepository agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpPost]
        public IActionResult BookAppointment([FromBody] Appointment appointment)
        {
            try
            {
                var bookedAppointment = _agencyService.BookAppointment(appointment.Customer, appointment.Date);
                return CreatedAtRoute("GetAppointment", new { id = bookedAppointment.Id }, bookedAppointment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTodaysAppointments()
        {
            var appointments = _agencyService.GetTodaysAppointments();
            return Ok(appointments);
        }

        [HttpGet("offDays")]
        public IActionResult GetOffDays()
        {
            var offDays = _agencyService.GetOffDays();
            return Ok(offDays);
        }
    }
}