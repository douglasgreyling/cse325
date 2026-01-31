# CSE325 Group Project

A Blazor Web Application built with .NET 10 and SQLite.

## Team Members

1. Joseph Uchenna Israel
2. Douglas Greyling

## Tech Stack

- **Framework**: .NET 10 Blazor Web App (Server-side rendering with interactive components)
- **Database**: SQLite with Entity Framework Core 10
- **ORM**: Entity Framework Core

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (version 10.0 or later)

Verify your installation:
```bash
dotnet --version
```

## Getting Started

### Clone the Repository

```bash
git clone <repository-url>
cd cse325
```

### Run the Application

```bash
dotnet run
```

The application will start and be available at:
- **HTTP**: http://localhost:5050
- **HTTPS**: https://localhost:5051

The SQLite database (`cse325app.db`) will be created automatically on first run.

### Build Only

```bash
dotnet build CSE325App.csproj
```

## Project Structure

```
cse325/
├── Components/          # Blazor components and pages
│   ├── Layout/         # Layout components
│   └── Pages/          # Page components
├── Data/               # Database context and data access
│   └── ApplicationDbContext.cs
├── Models/             # Data models/entities
├── Services/           # Business logic services
├── Authentication/     # Authentication-related code
├── Properties/         # Launch settings
├── wwwroot/           # Static files (CSS, JS, images)
├── appsettings.json           # Production configuration
├── appsettings.Development.json  # Development configuration
├── Program.cs         # Application entry point
└── CSE325App.csproj   # Project file
```

## Configuration

### Database Connection

The SQLite database connection is configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=cse325app.db"
  }
}
```

The database file is created in the project root directory.

### Environment Settings

- **Development**: Uses `appsettings.Development.json` with detailed logging and error messages
- **Production**: Uses `appsettings.json` with minimal logging

### Secrets Management

For sensitive configuration (API keys, etc.), use .NET User Secrets in development:

```bash
dotnet user-secrets init
dotnet user-secrets set "SomeSecret" "secret-value"
```

Access secrets via `IConfiguration` in the same way as appsettings values.

## Development

### Hot Reload

Hot reload is enabled by default in development. Changes to Razor components will automatically refresh in the browser.

To run with explicit hot reload:
```bash
dotnet watch
```

### Adding Database Migrations

When you add or modify models:

```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

Note: Install EF Core tools if not already installed:
```bash
dotnet tool install --global dotnet-ef
```

## Architecture Decisions

- **Blazor Web App (Server)**: Chosen for real-time interactivity with simpler deployment compared to WebAssembly
- **SQLite**: Lightweight, file-based database ideal for development and small-scale deployments
- **Entity Framework Core**: Industry-standard ORM for .NET with excellent SQLite support

## Files Not Tracked by Git

The following are excluded from version control (see `.gitignore`):
- `bin/` and `obj/` directories (build output)
- `*.db` files (SQLite database)
- `.vs/` and `.idea/` (IDE settings)
- `appsettings.*.local.json` (local configuration overrides)
