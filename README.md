# BMDb API

BMDb API is a RESTful API for a movie database built with ASP.NET Core (.NET 10) and Entity Framework Core.

## Features

- User authentication and authorization using JWT tokens with refresh tokens
- CRUD operations for movies with an admin role
- Search movies by title, genre, director, IMDB id and release date
- Pagination and sorting for movie lists

## Technologies Used

- ASP.NET Core (.NET 10)
- Entity Framework Core
- PostgreSQL
- FluentValidation
- JWT Bearer Authentication with email access-code confirmation (passwordless)
- CORS
- Serilog
- Swagger

## Endpoints

### Authentication

- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - Login with access code
- `POST /api/auth/refresh-token` - Refresh JWT token
- `POST /api/auth/forget-access-code` - Request a new access code
- `POST /api/auth/logout` - Logout the current user

### Movies

- `GET /api/movies` — Get all movies (with support for filtering, sorting, pagination, and search by title, genre,
  director, year)
- `GET /api/movies?title={title}` — Get movies by title
- `GET /api/movies?genre={genre}` — Get movies by genre
- `GET /api/movies?director={director}` — Get movies by director
- `GET /api/movies?year={year}` — Get movies by release year
- `GET /api/movies/{id}` — Get a movie by ID
- `GET /api/movies/imdb/{imdb}` — Get a movie by IMDB ID
- `GET /api/movies/random?limit={limit}` — Get random movies (with optional limit)

### Admin

- `POST /api/admin/add-movie` - Add a new movie
- `PUT /api/admin/update-movie/{id}` - Update a movie
- `DELETE /api/admin/delete-movie/{id}` - Delete a movie
- `GET /api/admin/get-by-id/{id}` - Get a movie by ID (admin)

## Architecture

The project follows a clean architecture pattern with the following layers:

- **Presentation Layer**: Contains the API controllers and Middlewares.
- **Core Layer**: Contains the business logic, application services, DTOs, and validators.
- **Infrastructure Layer**: Contains the data access layer (Entity Framework Core, repositories), JWT
  authentication wiring, and the JWT/email service implementations.
- **Domain Layer**: Contains the domain entities, shared response models (`ResponseModel`), and exception types.

## Client

The API has two clients: a Blazor WebAssembly application for user registration and access code recovery, and an Angular
application for user login and movie browsing.
