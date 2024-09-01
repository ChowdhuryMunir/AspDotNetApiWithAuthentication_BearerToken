# ASP.NET Web API with Bearer Token Authentication

This repository contains an ASP.NET Web API project built on the .NET Framework, showcasing Bearer Token authentication. The project implements secure token-based authentication and provides CRUD operations using a Master-Detail approach. 

## Features

- **Bearer Token Authentication**: Secures API endpoints using Bearer Tokens for authentication and authorization.
- **Token Management**: Includes token generation and validation for secure API access.
- **CRUD Operations**: Implements Create, Read, Update, and Delete functionalities.
- **Master-Detail Approach**: Manages complex data relationships effectively.

## Technologies Used

- **ASP.NET Web API**: Framework for building RESTful web services.
- **.NET Framework**: Platform for developing and running the application.
- **OAuth2**: Protocol used for Bearer Token authentication.
- **Owin**: Middleware for configuring authentication.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/) with support for ASP.NET Web API
- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) compatible with the project

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/ChowdhuryMunir/AspDotNetApiWithAuthentication_BearerToken.git
   cd AspDotNetApiWithAuthentication_BearerToken
   ```

2. **Open the Project**
   - Open the solution file (`.sln`) in Visual Studio.

3. **Update Configuration**
   - Open the `web.config` file and update the JWT settings:
     ```xml
     <appSettings>
       <add key="Jwt:Key" value="your_secret_key"/>
       <add key="Jwt:Issuer" value="your_issuer"/>
       <add key="Jwt:Audience" value="your_audience"/>
     </appSettings>
     ```

4. **Build the Project**
   - Restore NuGet packages and build the project using Visual Studio.

5. **Run the Application**
   - Start the application using Visual Studio. The API will be available at `http://localhost:your_port`.

## Project Structure

- **`MyAuthorizeServiceProvider.cs`**: Implements the `OAuthAuthorizationServerProvider` to handle token validation and user authentication. It validates user credentials and issues tokens.
- **`MyAuthorizeAttribute.cs`**: Custom authorization attribute that returns a forbidden response if the user is authenticated but lacks the necessary permissions.
- **`Startup.cs`**: Configures OWIN middleware for OAuth authentication and sets up the API’s authentication and authorization settings.

## API Endpoints

- **Authentication**:
  - `POST /login`: Authenticates user credentials and returns a Bearer token. Use the credentials `username: admin` and `password: admin` for testing.

- **CRUD Operations** (replace `resource` with your actual resource):
  - **Resource Management**:
    - `GET /api/resources`: Retrieve all resources.
    - `POST /api/resources`: Create a new resource.
    - `PUT /api/resources/{id}`: Update an existing resource.
    - `DELETE /api/resources/{id}`: Delete a resource.

## Usage

1. **Obtain a Bearer Token**: Send a POST request to the `/login` endpoint with valid credentials to receive a Bearer token.
2. **Authenticate Requests**: Include the Bearer token in the `Authorization` header of subsequent API requests.
3. **Perform CRUD Operations**: Use the appropriate endpoints to manage resources with token-based access control.

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push the branch (`git push origin feature/your-feature`).
5. Open a pull request with a description of your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please contact [MunirchowdhurySaif](https://github.com/chowdhuryMunir).
