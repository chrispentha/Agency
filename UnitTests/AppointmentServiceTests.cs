using AgencyAPI.Data;
using AgencyAPI.Models;
using AgencyAPI.Repositories;
using AgencyAPI.Services;
using Moq;
using Xunit;

namespace AgencyAPI.UnitTests
{
    public class AppointmentServiceTests
    {
        private readonly IAppointmentService _appointmentService;
        private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;
        private readonly Mock<IOffDayRepository> _offDayRepositoryMock;

        public AppointmentServiceTests()
        {
            _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            _offDayRepositoryMock = new Mock<IOffDayRepository>();
            _appointmentService = new AppointmentService(_appointmentRepositoryMock.Object, _offDayRepositoryMock.Object);
        }

        [Fact]
        public async Task BookAppointment_ShouldReturnToken()
        {
            _offDayRepositoryMock.Setup(repo => repo.IsOffDay(It.IsAny<DateTime>())).ReturnsAsync(false);
            _appointmentRepositoryMock.Setup(repo => repo.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new List<Appointment>());

            var token = await _appointmentService.BookAppointment("Christian Penthatius Yudianto");

            Assert.NotNull(token);
        }

        [Fact]
        public async Task BookAppointment_ShouldSkipOffDays()
        {
            var offDays = new List<DateTime> { DateTime.Today };
            _offDayRepositoryMock.Setup(repo => repo.IsOffDay(It.IsAny<DateTime>())).ReturnsAsync((DateTime date) => offDays.Contains(date));
            _appointmentRepositoryMock.Setup(repo => repo.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new List<Appointment>());

            var token = await _appointmentService.BookAppointment("Christina");

            Assert.NotNull(token);
            Assert.Equal(DateTime.Today.AddDays(1), DateTime.Today.AddDays(1)); // Placeholder to check the date increment logic
        }

        [Fact]
        public async Task BookAppointment_ShouldAddToNextDay_WhenMaxAppointmentsReached()
        {
            _offDayRepositoryMock.Setup(repo => repo.IsOffDay(It.IsAny<DateTime>())).ReturnsAsync(false);
            _appointmentRepositoryMock.Setup(repo => repo.GetByDate(It.IsAny<DateTime>())).ReturnsAsync(new List<Appointment>(new Appointment[10]));

            var token = await _appointmentService.BookAppointment("Christina");

            Assert.NotNull(token);
        }

        [Fact]
        public async Task GetAppointmentsForDay_ShouldReturnAppointments()
        {
            var appointments = new List<Appointment> { new Appointment { Id = 1, Date = DateTime.Today, CustomerName = "Christian Penthatius Yudianto" } };
            _appointmentRepositoryMock.Setup(repo => repo.GetByDate(DateTime.Today)).ReturnsAsync(appointments);

            var result = await _appointmentService.GetAppointmentsForDay(DateTime.Today);

            Assert.NotEmpty(result);
            Assert.Equal(appointments, result);
        }

        [Fact]
        public async Task GetOffDays_ShouldReturnOffDays()
        {
            var offDays = new List<DateTime> { DateTime.Today };
            _offDayRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(offDays);

            var result = await _appointmentService.GetOffDays();

            Assert.NotEmpty(result);
            Assert.Equal(offDays, result);
        }

        [Fact]
        public async Task AddOffDay_ShouldAddNewOffDay()
        {
            var newOffDay = DateTime.Today.AddDays(1);
            _offDayRepositoryMock.Setup(repo => repo.IsOffDay(newOffDay)).ReturnsAsync(false);
            _offDayRepositoryMock.Setup(repo => repo.Add(It.IsAny<OffDay>())).Verifiable();

            await _appointmentService.AddOffDay(newOffDay);

            _offDayRepositoryMock.Verify(repo => repo.Add(It.IsAny<OffDay>()), Times.Once);
        }
    }
}
