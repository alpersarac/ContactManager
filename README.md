# Contact Manager REST API

This is a code-first Contact Manager REST API developed in C# .NET 6. To run the application properly, please follow the instructions below.

## Getting Started

### Prerequisites

Before you begin, make sure you have the following:

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) installed on your machine.
- A PostgreSQL database server up and running.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/alpersarac/ContactManager.git
   ```

2. Set your connection string in `appsettings.json`:

   Example:
   ```json
   "DefaultConnection": "Host=localhost;Database=ContactManager;Username=postgres;Password=123123456"
   ```

3. Open Package Manager Console in Visual Studio (View -> Other Windows -> Package Manager Console).

4. Add a migration. Make sure you have selected `ContactManager.DataAccess` as the default project:

   ```bash
   add-migration InitialMigration
   ```

5. Run the database update command:

   ```bash
   update-database
   ```

6. The application should now work properly.

## Testing

You can test the API using Swagger. Access the Swagger interface at the following URL:

[Swagger](https://github.com/alpersarac/ContactManager)

## Contact

For any questions or feedback, please contact:

Alper Sarac
- Email: alper.sarac42@gmail.com
- GitHub: [alpersarac](https://github.com/alpersarac)

Last updated: 10/09/2023
