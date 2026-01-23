# AgencyWebApp — Enterprise Travel Management System (Backend)

## 📖 Project Overview
AgencyWebApp is a high-performance, scalable backend solution for travel agencies. It is designed to manage complex data relations between **Tours, Hotels, Flights, and User Bookings**. The project serves as a centralized API that provides secure data access to client applications (Blazor, Mobile, or Web).

---

## 🏛 Architecture: Why Clean Architecture?

This project is built using **Clean Architecture** (Onion Architecture). The main goal is to separate the business logic from external concerns like databases, frameworks, and UI.



### Layer Breakdown:
1. **Domain (Core)**: 
   - Contains the "Enterprise Logic".
   - Includes: Entities, Enums, and Base Classes.
   - *Independence*: This layer has **zero** dependencies on any other layer or library (like EF Core).
   
2. **Application (Use Cases)**:
   - Orchestrates the flow of data to and from the domain.
   - Includes: Interfaces, DTOs, AutoMapper Profiles, and Service Implementations.
   - *Key Rule*: Defines interfaces (like `IHotelRepository`) that are implemented in the Infrastructure layer.

3. **Infrastructure (Data & Tools)**:
   - Handles everything that is external to the application.
   - Includes: `AppDbContext`, SQL Server Migrations, Repository implementations, and Identity configuration.
   
4. **Presentation (API)**:
   - The "Face" of the application.
   - Includes: Controllers, Middlewares (Error handling, Auth), and Program.cs.

---

## 🛠 Technology Stack & Packages

### Core Framework
* **.NET 8.0**: The latest LTS version for high-performance backend.
* **C# 12**: Utilizing modern language features like primary constructors and required members.

### Data Access (Infrastructure)
* **Entity Framework Core**: The primary ORM for database communication.
* **EF Core SQL Server**: Database provider for MS SQL Server.
* **EF Core Tools & Design**: Used for managing migrations via CLI.

### Security & Authentication
* **ASP.NET Core Identity**: For managing users, passwords, and roles.
* **JWT (JSON Web Tokens)**: Used for stateless authentication between Frontend and Backend.
* **BCrypt.Net-Next**: High-security password hashing.

### Mapping 
* **AutoMapper**: For seamless mapping between Domain Entities and Application DTOs.

### API Documentation
* **Swagger (Swashbuckle)**: Interactive API documentation and testing interface.

---

## 📦 Key NuGet Packages Used

| Package | Purpose | Layer |
| :--- | :--- | :--- |
| `Microsoft.EntityFrameworkCore.SqlServer` | SQL Database Provider | Infrastructure |
| `Microsoft.EntityFrameworkCore.Tools` | Migration CLI tools | Infrastructure |
| `Microsoft.AspNetCore.Authentication.JwtBearer` | JWT Logic | Presentation |
| `AutoMapper` | Object-to-Object mapping | Application |
| `Microsoft.AspNetCore.Identity.EntityFrameworkCore` | Identity Integration | Infrastructure |
| `Microsoft.Data.SqlClient` | Low-level SQL communication | Infrastructure |

---

## ⚙️ Core Functionalities

1. **Service Management**:
   - CRUD for **Hotels** (location, pricing, rating, status).
   - CRUD for **Tours** (regions, durations, photo management).
   - CRUD for **Flights** (schedules, flight numbers, status tracking).

2. **Advanced Filtering**: 
   - Server-side filtering and sorting for large datasets to ensure high performance on the frontend.

3. **Role-Based Access Control (RBAC)**:
   - Secure endpoints where `Admin` can modify data, while `User` can only read and book.

4. **Status System**:
   - Integrated status tracking (`Active`, `Draft`, `Archived`) for all travel products.

---

## 🛠 Development Workflow

### How to add a new feature (e.g., "Car Rental"):
1. **Domain**: Create `Car.cs` entity.
2. **Infrastructure**: Add `DbSet<Car>` to `AppDbContext` and run `migrations add`.
3. **Application**: Create `CarDto.cs` and `ICarService`.
4. **Presentation**: Create `CarsController.cs` to expose the endpoints.

---

## 🚀 Deployment & Installation

1. **Clone the repo**: `git clone https://github.com/Abdulaziz77-Developer/AgencyWebApp.git`
2. **Configure Database**: Set your `DefaultConnection` in `appsettings.json`.
3. **Migrate**: `dotnet ef database update`.
4. **Run**: `dotnet run`.

---

## 👥 Contributors
- **Lead Developer**: [Abdulaziz/https://github.com/Abdulaziz77-Developer]