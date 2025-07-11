# BMDb API

BMDb API a RESTful API for a movie database built with ASP.NET Core and Entity Framework Core.

## Features

- User authentication and authorization using JWT tokens with refresh tokens
- CRUD operations for movies with an admin role
- Search movies by title, genre, director, IMDB id and release date
- Pagination and sorting for movie lists

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- PostgresSQL
- AutoMapper
- FluentValidation
- JWT Bearer Authentication with Email Confirmation
- Cors
- Serilog
- Swagger
- Amazon S3 for movie poster storage

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
- `GET /api/movies/get-by-id/{id}` - Get a movie by ID

## Architecture

The project follows a clean architecture pattern with the following layers:

- **Presentation Layer**: Contains the API controllers and Middlewares.
- **Core Layer**: Contains the business logic and application services.
- **Infrastructure Layer**: Contains the data access layer, including Entity Framework Core and repository pattern.
- **Domain Layer**: Contains the domain entities.

## Client

The API has two clients: a Blazor WebAssembly application for user registration and access code recovery, and an Angular
application for user login and movie browsing.