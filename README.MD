# Car Stocks API

The Car Stocks API is a .NET 6 web application that allows dealers to manage their car stocks. This API supports various functions related to car management, including listing cars, updating stock levels, and searching for cars by make and model. Users are required to register and log in to access and manage their car stocks securely.

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/get-started)
- A code editor (e.g., Visual Studio, Visual Studio Code)


User Registration
To access the API, users need to register an account. The registration requires the following information:

Username
Password (with at least 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character)
Email
User Login
After registration, users can log in using their registered credentials.

Authentication
This API uses JWT (JSON Web Token) for authentication. Upon successful login, users receive a JWT token, which they need to paste the JWT token into the Authorize's button. 
