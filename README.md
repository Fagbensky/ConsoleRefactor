# User Management System - Clean Architecture/SOLID Implementation

## Overview
This project implements a **User Management System** following **Clean Architecture** and **SOLID** principles. The system allows users to add, remove, and view user reports interactively through a **Console Application**. It is built with modularity, testability, and maintainability in mind, ensuring clear separation of concerns across layers.

## Project Structure
The project has been refactored into multiple layers based on **Clean Architecture** and **SOLID** principles:

### Layer Explanation
1. **Domain Layer** (`Ibridge.Domain`):
   - Contains core business entities (e.g., `User`).
   - Entities represent the fundamental data and business rules.

2. **Application Layer** (`Ibridge.Application`):
   - Contains business logic in the form of services.
   - Defines interfaces for repositories and services to decouple implementations.

3. **Infrastructure Layer** (`Ibridge.Infrastructure`):
   - Implements repository interfaces.
   - Provides an in-memory storage solution for users as an example.

4. **Presentation Layer** (`Ibridge`):
   - A console-based UI that interacts with the application layer.
   - Provides a menu-driven interface for user interaction.

5. **Test Layer** (`Ibridge.test`):
   - Contains unit tests for services and repository implementations.
   - Tests use `xUnit` and `Moq` for mocking dependencies.

## Key Changes and Rationale
### 1. **Separation of Concerns**
- The monolithic `UserManager` class was split into multiple layers:
  - `User` entity (Domain Layer).
  - `IUserRepository`, `IUserService` and `IReportService` interfaces (Application Layer).
  - `UserService` and `ReportService` for business logic.
  - `InMemoryUserRepository` as a simple implementation for data persistence.
- This separation ensures that each layer has a single responsibility, making the system easier to maintain and extend.

### 2. **Repository Pattern**
- Introduced the `IUserRepository` interface to abstract the data storage implementation.
- Implemented `InMemoryUserRepository` for demonstration purposes.
- This allows us to switch out the data source (e.g., to a database) without affecting the rest of the system.

### 3. **Service Layer**
- Created `IUserService` and `UserService` for business logic operations:
  - Adding a user.
  - Removing a user.
  - Retrieving all users.
- Added `IReportService` and `ReportService` to generate user reports.
- Services ensure that business logic is centralized and reusable.

### 4. **Interactive Console Application**
- Refactored the `Program.cs` to provide a clean, menu-driven user interface.
- Users can perform the following operations interactively:
  - Add a user.
  - Remove a user.
  - Generate and display user reports.
  - Exit the application.
- Input validation was added to handle empty inputs gracefully.

### 5. **Unit Testing**
- Added a dedicated test project (`Ibridge.test`) with the following tests:
  - **UserServiceTests**: Tests `AddUser`, `RemoveUser`, and `GetAllUsers` using `Moq`.
  - **ReportServiceTests**: Ensures `GenerateReport` works correctly for different scenarios.
  - **InMemoryUserRepositoryTests**: Tests repository CRUD operations.
- Unit tests ensure that individual components work as expected, improving reliability and confidence in the codebase.

### 6. **Clean Architecture Principles/SOLID**
The refactoring adheres to the following principles:
- **Dependency Inversion**: Higher-level modules (services) depend on abstractions (interfaces), not concrete implementations.
- **Single Responsibility (Separation of Concerns)**: Each layer has a distinct purpose and responsibility.
- **Testability**: Components are decoupled, making it easier to write unit tests.
- **Maintainability**: New features can be added without affecting existing code, thanks to the modular design.
