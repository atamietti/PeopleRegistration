# 1. People Registration 


The People Registration is Basic API and Blazor Wasm CRUD Project

## Clean Architecture
The API is **ready to follow a based** clean architecture pattern, separating concerns into distinct layers:
- **Domain Layer**: Contains business domain entities.
- **Infrastructure Layer**: Handles data access and persistence.
- **Service Layer**: Provides application logic and orchestrates tasks between the domain and infrastructure layers.

## Feature Folder
The project is organized using the feature folder structure, which groups related files by feature rather than by type (or csproj). 

## CORS Support
- Configured to allow cross-origin requests, enabling access from different domains.

```c#
builder.Services.AddCors(options =>
{
    options.AddPolicy("myPolicy",
        builder => builder.WithOrigins("*")  //Configure Origins Here
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

```


# Getting Started

### Prerequisites
- .NET SDK (version 8.0 or higher)
- SQL Server or any compatible database

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/PeopleRegistration.git
   cd PeopleRegistration
   ```

2. Update the `appsettings.json` file with your database connection string:
`PeopleRegistration.API/appsettings.json`
   ```json
   {
    //...
     "Config": {
       "PeopleRegistrationDBContext": "CONNECTION_STRING"
     }
   }
   ```
   `PeopleRegistration.Client/appsettings.json`
   ```json
   {
    //...
     "Config": {
       "PeopleRegistrationApi": "API_ADDRESS"
     }
   }
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Run database migrations:
   ```bash
   dotnet ef database update --project PeopleRegistration.API\PeopleRegistration.API.csproj
   ```

5. Start the application:
   ```bash

   dotnet run --project PeopleRegistration.API\PeopleRegistration.API.csproj

   dotnet run --project PeopleRegistration.Client\PeopleRegistration.Client.csproj
   
   ```
