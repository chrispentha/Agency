//using AgencyAPI.Models;
////using static AgencyAPI.AgencyContext;
//using Xunit;
////using Microsoft.EntityFrameworkCore.InMemory;
////using System.Collections.Generic;

//namespace AgencyAPI.Data
//{
//    public class AgencyRepositoryUnitTests
//    {
//        private InMemoryDbContextOptions<AgencyContext> _options;
//        private AgencyContext _context;

//        public AgencyRepositoryUnitTests()
//        {
//            _options = new InMemoryDbContextOptionsBuilder<AgencyContext>()
//                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique name for each test
//                .Options;
//            _context = new AgencyContext(_options);
//        }

//        [Fact]
//        public void BookAppointment_ShouldSucceedForAvailableSlot()
//        {
//            // Arrange
//            var desiredDate = DateTime.Today.AddDays(1); // Tomorrow's date
//            var customer = new Customer { Name = "John Doe" };

//            var repository = new AgencyRepository(_context); // Inject in-memory context

//            // Act
//            var bookedAppointment = repository.BookAppointment(customer, desiredDate);

//            // Assert
//            Assert.NotNull(bookedAppointment); // Verify appointment is not null
//            Assert.Equal(desiredDate, bookedAppointment.Date); // Verify booked date
//            Assert.Equal(1, bookedAppointment.Token); // Verify token (first appointment)
//        }

//        [Fact]
//        public void BookAppointment_ShouldThrowExceptionOnOffDay()
//        {
//            // Arrange
//            var offDay = DateTime.Today; // Today is an off day (assuming logic exists)
//            var customer = new Customer { Name = "Jane Doe" };

//            DateTime date1 = DateTime.Now;
//            DateTime date2 = DateTime.Now.AddDays(1);

//            var offDays = new IEnumerable<DateTime>() { date1, date2 };

//            var repository = new AgencyRepository(_context, 10, offDays); // Inject in-memory context

//            // Act & Assert
//            Assert.Throws<Exception>(() => repository.BookAppointment(customer, offDay));
//        }
//    }
//}
