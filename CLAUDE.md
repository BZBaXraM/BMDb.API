# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build the solution
dotnet build BMDb.sln

# Run the API
dotnet run --project BMDb.API/BMDb.API.csproj

# Apply EF Core migrations (MovieContext)
dotnet ef database update --project BMDb.Infrastructure --startup-project BMDb.API --context MovieContext

# Add a new migration for MovieContext
dotnet ef migrations add <MigrationName> --project BMDb.Infrastructure --startup-project BMDb.API --context MovieContext
```

> `AuthContext` and its `IdentityConnection` are currently commented out (in `DependencyInjection.AddInfrastructure` and `DatabaseExtensions`). The app runs on a single `MovieContext`/`DefaultConnection` database.

## Architecture

Clean architecture with four layers:

- **BMDb.Domain** — entities (`Movie`, `User`), shared response types (`Common/ResponseModel`), and exception types (`Exceptions/ApiException`). No dependencies on other layers.
- **BMDb.Core** — business logic, service interfaces, business service implementations (`AuthService`, `AdminService`, `MoviesService`, `BlackListService`), DTOs, FluentValidation validators, JWT/email configs. References Domain.
- **BMDb.Infrastructure** — EF Core DbContexts (`MovieContext`, `AuthContext`), repository implementations, the `JwtService` and `EmailService` implementations, JWT authentication/authorization wiring, migrations, database seeding. References Core and Domain.
- **BMDb.API** — ASP.NET Core controllers, middleware, DI wiring, Serilog setup. References Core and Infrastructure.

DI is split across three static classes: `DependencyInjection.AddInfrastructure` (repos + DbContexts + JwtService/EmailService + JWT auth/authorization policies), `DependencyInjection.AddCore` (business services + EmailConfig + FluentValidation), and `Di.AddServices` (controllers + Serilog + Swagger + CORS + middleware). `AddInfrastructure` is called before `AddCore` in `Program.cs`.

## Key Design Decisions

**Single database (currently)**: `MovieContext` holds both `DbSet<Movie>` and `DbSet<User>` and uses the `DefaultConnection` PostgreSQL database. `AuthContext` and its `IdentityConnection` still exist in the source but are commented out everywhere (DI registration, migration, and seeding), so users currently live in the same database as movies. The second-database wiring can be re-enabled by uncommenting those blocks.

**Authentication flow**: Users register with email → receive a short access code (first 6 chars of a GUID) via SMTP → log in with that access code → get a JWT access token + refresh token. There is no password. The `Role` claim (`"Admin"` or `"User"`) is embedded in the JWT and enforced via named authorization policies.

**Token blacklisting**: `BlackListService` (singleton, in-memory `HashSet`) stores revoked tokens. `BlackListMiddleware` intercepts every request before authentication to reject blacklisted tokens.

**Entity-to-DTO mapping**: Done with extension methods in `BMDb.Core/Extensions/MovieMappingExtensions.cs` — `movie.ToDto()` and `request.ToEntity()`. AutoMapper was intentionally removed.

**Response envelope**: Services return `ResponseModel` / `ResponseModel<T>` (in `BMDb.Domain/Common`) carrying `IsSucceeded`, `Message`, `StatusCode`, and optional `Errors`. Static factory helpers (`ResponseModel.Success(...)`, `ResponseModel.Failure(...)`) construct results. The `ApiException` type lives in `BMDb.Domain/Exceptions`.

**Admin vs User split**: `AdminController` (requires `"Admin"` policy) handles write operations. `MoviesController` (public or `"User"` policy) handles reads.

**Database seeding**: On startup, `InitialiseDatabaseAsync` runs `MovieContext` EF migrations then seeds classic movies (from `InitData.Movies`) if the Movies table is empty.

## Infrastructure Notes

- Targets **.NET 10** (`net10.0`).
- PostgreSQL on `localhost:5432`. `DefaultConnection` → `MovieDb` (active). `IdentityConnection` → `AuthDb` is configured but unused while `AuthContext` is disabled (see `appsettings.json` for credentials).
- `AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true)` is set in `Program.cs` — required for DateTime handling with Npgsql.
- Serilog logs to console and `/Logs/BMDb.txt` (rolling daily).
- The Blazor WebAssembly client in `Client/BMDb.AccessCode` is a thin frontend for user registration and access code recovery only.
