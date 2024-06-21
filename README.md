# Appointment Booking System

This is an appointment booking system for an agency, implemented using .NET 8 C#. 
The system allows customers to book appointments and get tokens, and the agency can view the appointments for the day. 
The project includes functionalities for managing off days and limiting the number of appointments per day.

## Frameworks and Tools Used

- **.NET 8**
- **Entity Framework Core**
- **SQL Server**
- **xUnit** (for unit testing)
- **Moq** (for mocking in unit tests)
- **Swagger** (for API documentation)
- **GitHub** (for source control)

## Tools Not Used
- **Autofac** (for Dependency Injection): because using AddScoped() Dependency Injection from .NET
- **Azure** (for cloud hosting): because getting stuck when sign up, I didn't know why. So sorry for that.

## Features

- Book appointments and issue tokens.
- View the queue of customers with appointments for the day.
- Specify off days (public holidays).
- Limit the maximum number of appointments per day, with overflow handled by the next day.

## Setup and Run

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (or any other IDE that supports .NET 8)

### Configuration

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/yourusername/appointment-booking-system.git
   cd appointment-booking-system
   ```

2. **Project Structure**:
   ```
   AppointmentBookingSystem
   │
   ├── AgencyAPI
   │   ├── Controllers
   │   │   ├── AppointmentsController.cs
   │   │   └── OffDaysController.cs
   │   ├── Data
   │   │   ├── ApplicationDbContext.cs
   │   │   └── Migrations
   │   ├── Models
   │   │   ├── Appointment.cs
   │   │   └── OffDay.cs
   │   ├── Repositories
   │   │   ├── AppointmentRepository.cs
   │   │   ├── IAppointmentRepository.cs
   │   │   ├── IOffDayRepository.cs
   │   │   └── OffDayRepository.cs
   │   ├── Services
   │   │   ├── AppointmentService.cs
   │   │   └── IAppointmentService.cs
   │   ├── Program.cs
   │   └── appsettings.json
   │
   ├── AgencyAPI.Tests
   │   ├── AppointmentServiceTests.cs
   │   └── AppointmentsControllerTests.cs
   │
   └── AgencyAPI.sln
   ```

3. **Setup SQL Server Database**:
   - Ensure SQL Server is running.
   - Update the connection string in `appsettings.json`
     ```
		{
		  "ConnectionStrings": {
			"DefaultConnection": "Server=your_server_name;Database=AppointmentDb;Trusted_Connection=True;MultipleActiveResultSets=true"
		  }
		}
	 ```

4. **Apply Migration**
   - Open a terminal in the project directory and run:
	  1. dotnet ef migrations add InitialMigration
	  2. dotnet ef database update

5. **Running the Application**
   - Build and Run:
		1. Open the solution in Visual Studio.
		2. Set AgencyAPI as the startup project.
		3. Press F5 to build and run the application.
   - Running the Unit Tests:
		1. Open the Test Explorer in Visual Studio (Test -> Test Explorer).
		2. Click Run All to run all the unit tests.
   - API Documentation:
		1. Swagger is integrated for API documentation.
		2. Once the application is running, navigate to https://localhost:5001/swagger 
		   to view and interact with the API documentation.
		   
## Additional Notes
This `README.md` file provides a concise and clear guide for setting up, running, and understanding the project, 
as well as information on the tools and frameworks used. Adjust the repository URL and any other specific details to fit your project.
