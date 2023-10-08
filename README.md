# WebAssessment
C# + SQL SERVER

CDN API - Complete Developer Network API
CDN API is a RESTful Web API that allows you to manage user data for the Complete Developer Network. It provides endpoints for registering, updating, deleting, and retrieving user information.


Getting Started
Prerequisites
.NET 5.0 or later
A relational database (e.g., SQL Server) with a configured connection string.
Installation
Clone the repository:


git clone https://github.com/yourusername/cdn-api.git
Navigate to the project directory:


cd cdn-api
Update the database connection string in appsettings.json to point to your database.

Run the application:


dotnet run
The API will be accessible at https://localhost:5001 (or http://localhost:5000).

Endpoints
The API provides the following endpoints:

GET /api/users: Get a list of all registered users.
POST /api/users: Register a new user.
PUT /api/users/{id}: Update an existing user's information by ID.
DELETE /api/users/{id}: Delete a user by ID.
Validation
The API includes validation for user data:

Username: Only letters, numbers, and underscores are allowed.
Phone Number: Only numbers are allowed.
Mail: Must be a valid email address.
Validation errors are returned with descriptive error messages.

Database
The API uses Entity Framework Core to interact with a relational database. The database schema includes a Users table to store user information.

Usage
You can use tools like Postman, Swagger, or your favorite HTTP client to interact with the API. Here are some example requests:

Get All Users
GET /api/users

Register a New User
POST /api/users
Content-Type: application/json
{
  "username": "newuser",
  "mail": "newuser@example.com",
  "phoneNumber": "1234567890",
  "skillsets": "Web Development",
  "hobby": "Reading"
}

Update User Information
PUT /api/users/{id}
Content-Type: application/json
{
  "mail": "updateduser@example.com"
}

Delete a User
DELETE /api/users/{id}

Allowed Hosts
"AllowedHosts": "*"
The "AllowedHosts" setting specifies which hosts are allowed to connect to the application. In this configuration, any host is allowed. In a production environment, it's recommended to specify only the trusted hosts to enhance security.

Connection Strings
"ConnectionStrings": {
  "WebAssessmentContext": "Server=PHYMAGE;Database=webLCY;User Id=testing;Password=LCY8899@;Encrypt=true;TrustServerCertificate=true;"
}

The "ConnectionStrings" section contains the connection string used to connect to the database. You can modify this section to specify the database server, name, credentials, and encryption settings based on your database setup.

Remember to update the configuration in the appsettings.json file as needed to match your environment and database configuration.

Contributing
Contributions are welcome! If you'd like to contribute to this project, please follow the standard GitHub Fork and Pull Request workflow.

License
This project is released under The Unlicense, which means it is free and open-source software with no restrictions. You can use, modify, and distribute it as you see fit, without any limitations or obligations.


Feel free to customize this README further to provide more details about your project and how to use it with ID-based HttpPut and HttpDelete endpoints.
