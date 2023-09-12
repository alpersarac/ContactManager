
# Contact Manager REST API

This is a code-first Contact Manager REST API developed in C# .NET 6. To run the application properly, please follow the instructions below.

# Project Update - 12th of September, 2023

## Overview
This update introduces some important changes and enhancements to our project. Please find the details below.

## Changes

### Mistake Fix
- Previously, there was a mistake that prevented users from updating their email addresses using their own email addresses. This issue has been resolved, and now users can successfully update their email information.

### Enhancement: Creating and Updating a Contact
- To improve the process of creating and updating contact information, we have made the following enhancement:
  - Instead of requiring individual parameters such as Id, creationTimestamp, lastChangeTimestamp, and notifyHasBirthdaySoon, we now use the `ContactDTO` class. This change simplifies the process by allowing users to provide only the desired fields when working with contacts.

I believe that these changes will enhance the usability and flexibility of the project. Thank you for your continued support and feedback!

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

You can test the API using Swagger.

## Contact

For any questions or feedback, please contact:

Alper Sarac
- Email: alper.sarac42@gmail.com
- GitHub: [alpersarac](https://github.com/alpersarac)

Last updated: 10/09/2023
