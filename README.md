# fleetRutePro

fleetRutePro is a .NET Core 6.0 API project designed to manage a fleet of vehicles, including their drivers, routes, and schedules.
Getting Started

## To get started with fleetRutePro, follow these steps:

    Clone this repository to your local machine.
    Open the project in your preferred IDE or text editor.
    Run the project using dotnet run or your IDE's built-in run functionality.
    Navigate to http://localhost:5000 in your web browser to access the API.

# API Endpoints
## Vehicles

    GET /api/vehicles: Get a list of all vehicles.
    GET /api/vehicles/{id}: Get details of a specific vehicle by ID.
    POST /api/vehicles: Create a new vehicle.
    PUT /api/vehicles/{id}: Update details of a specific vehicle by ID.
    DELETE /api/vehicles/{id}: Delete a specific vehicle by ID.

## Drivers

    GET /api/drivers: Get a list of all drivers.
    GET /api/drivers/{id}: Get details of a specific driver by ID.
    POST /api/drivers: Create a new driver.
    PUT /api/drivers/{id}: Update details of a specific driver by ID.
    DELETE /api/drivers/{id}: Delete a specific driver by ID.

Routes

    GET /api/routes: Get a list of all routes.
    GET /api/routes/{id}: Get details of a specific route by ID.
    POST /api/routes: Create a new route.
    PUT /api/routes/{id}: Update details of a specific route by ID.
    DELETE /api/routes/{id}: Delete a specific route by ID.

## Schedules

    GET /api/schedules: Get a list of all schedules.
    GET /api/schedules/{id}: Get details of a specific schedule by ID.
    POST /api/schedules: Create a new schedule.
    PUT /api/schedules/{id}: Update details of a specific schedule by ID.
    DELETE /api/schedules/{id}: Delete a specific schedule by ID.

# Technologies Used

    .NET Core 6.0
    Entity Framework Core
    ASP.NET Core Web API
    Swagger UI

# License

This project is licensed under the MIT License - see the LICENSE file for details.