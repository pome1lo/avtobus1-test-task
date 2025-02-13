# URL Shortener

A URL shortener service built with .NET Core 8 and MySQL (MariaDB 10.3). The application allows users to generate short links, track redirects, and manage URLs.

## Features
- Generate short and unpredictable URLs.
- Track the number of visits.
- CRUD operations for managing short links.
- Automatic database migrations.
- Input validation to ensure correct URL formatting.

## Project Structure
The project follows a structured architecture to showcase clean coding practices and scalability.

## Setup and Installation
### Prerequisites
- .NET Core 8
- MySQL (MariaDB 10.3)

### Steps to Run the Project
1. Update the database connection string in `appsettings.json`.
2. Apply migrations:
   ```sh
   dotnet ef database update
   ```
3. Ensure that the tables are successfully created in the database.
4. Run the application:
   ```sh
   dotnet run
   ```

## API Endpoints
### Create a Short Link
```
POST /api/shortlinks
```
**Request Body:**
```json
"https://example.com"
```

### Get All Short Links
```
GET /api/shortlinks
```

### Redirect to Original URL
```
GET /api/shortlinks/redirect/{shortUrl}
```

### Update a Short Link
```
PUT /api/shortlinks/{id}
```
**Request Body:**
```json
{
  "newOriginalUrl": "https://new-example.com"
}
```

### Delete a Short Link
```
DELETE /api/shortlinks/{id}
```

