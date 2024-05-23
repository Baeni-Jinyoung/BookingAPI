# BookingAPI

## Installation
1. Clone this repository.
- `git clone git@github.com:Baeni-Jinyoung/BookingAPI.git`  

2. Build the project.
-`cd BookingAPI
dotnet build`

3. Run the app.
-`dotnet run`

4. The server will be running at `http://localhost:3000`

## Tests
1. Go to the test project.
-`cd BokingAPI.Tests`

2. Run the test command
-`dotnet test`

This will execute all the unit tests in the project and provide the test results.

### Structure
```js
BookingApi/
│
├── BookingApi/
│   ├── Controllers/
│   │   └── BookingController.cs
│   ├── Models/
│   │   ├── Booking.cs
│   │   └── BookingRequest.cs
│   ├── Services/
│   │   └── BookingService.cs
│   ├── Interfaces/
│   │   └── IBookingService.cs
│   └── Program.cs
│
└── BookingApi.Tests/
    ├── BookingServiceTests.cs


```
## HTTP Response Status Codes
- `200 OK`: The request was successful.
- `400 Bad Request`: The request could not be understood due to invalid syntax or missing required parameters.
- `409 Conflict`: The request conflicts with the current state of the server. For example, attempting to create a reservation at a time slot that is already booked.
- `500 Internal Server Error`: The server encountered an unexpected condition that prevented it from fulfilling the request.
