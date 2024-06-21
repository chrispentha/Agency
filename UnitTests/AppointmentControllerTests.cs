using AgencyAPI.Controllers;
using AgencyAPI.Models;
using AgencyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AgencyAPI.UnitTests
{
    public class AppointmentsControllerTests
    {
        private readonly AppointmentsController _controller;
        private readonly Mock<IAppointmentService> _appointmentServiceMock;

        public AppointmentsControllerTests()
        {
            _appointmentServiceMock = new Mock<IAppointmentService>();
            _controller = new AppointmentsController(_appointmentServiceMock.Object);
        }

        [Fact]
        public async Task GetAppointmentsForDay_ShouldReturnOk()
        {
            _appointmentServiceMock.Setup(service => service.GetAppointmentsForDay(It.IsAny<DateTime>()))
                .ReturnsAsync(new List<Appointment>());

            var result = await _controller.GetAppointmentsForDay(DateTime.Today);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task BookAppointment_ShouldReturnOkWithToken()
        {
            _appointmentServiceMock.Setup(service => service.BookAppointment(It.IsAny<string>()))
                .ReturnsAsync("test-token");

            var result = await _controller.BookAppointment("Christian Penthatius Yudianto");

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(new { Token = "test-token" }, okResult.Value);
        }

        [Fact]
        public async Task GetOffDays_ShouldReturnOk()
        {
            _appointmentServiceMock.Setup(service => service.GetOffDays())
                .ReturnsAsync(new List<DateTime> { DateTime.Today });

            var result = await _controller.GetOffDays();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task AddOffDay_ShouldReturnOk()
        {
            _appointmentServiceMock.Setup(service => service.AddOffDay(It.IsAny<DateTime>()))
                .Returns(Task.CompletedTask);

            var result = await _controller.AddOffDay(DateTime.Today);

            Assert.IsType<OkResult>(result);
        }
    }
}
