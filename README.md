**School Management API**

**Overview**

This is a .NET 6 Web API project designed to manage school data, including teachers and courses, using both SQL Server and MongoDB as databases.
The API features AutoMapper for object mapping, and Swagger for API documentation.

**Features**

Fetch teachers and courses from both SQL Server and MongoDB.
Add teachers and courses to both SQL Server and MongoDB.
Combine data from SQL Server and MongoDB.
Secure API endpoints using JWT-based authentication.
AutoMapper integration for mapping between entities and DTOs.
Swagger integration for API documentation.
Contains unit tests for various scenarios using xUnit and Moq.
Containerized using Docker for easy deployment.

**Technologies**

.NET 6
SQL Server
MongoDB (via MongoDB Compass)
AutoMapper
Swagger for API Documentation
Moq (Mocking in unit tests)
Docker

**Requirements**

.NET 6 SDK
SQL Server (LocalDB or a full installation)
MongoDB Compass
MongoDB server instance
Visual Studio or any IDE for .NET development
Docker (for containerization)

**Setup Instructions**

1. Clone the Repository
2. Configure Connection Strings - Update the appsettings.json file with your SQL Server and MongoDB connection strings.
3. Install Dependencies
4. Update MongoDB Database via Compass
  - Open MongoDB Compass.
  - Connect to your MongoDB server instance.
  - Create a database named schoolDb and collections named Teachers and Courses.
5. Running the Application
  The API will start at https://localhost:5001 or http://localhost:5000.
6. Accessing Swagger UI
  Navigate to https://localhost:5001/swagger to explore the API documentation.

**API Endpoints**

GET /api/data/sql - Get teachers from SQL Server.
GET /api/data/mongo - Get teachers from MongoDB.
GET /api/data/combined - Get teachers from both SQL Server and MongoDB.
POST /api/data - Add a new teacher to both SQL Server and MongoDB.

**NuGet Packages**

This project uses the following NuGet packages:

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
MongoDB.Driver
AutoMapper
Swashbuckle.AspNetCore (for Swagger)
