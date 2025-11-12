# 🧾 ToDo List API (ASP.NET Core + PostgreSQL)

A simple RESTful API built with **ASP.NET Core**, following market best practices and clean architecture principles.  
The API manages tasks (ToDos) and connects to a **PostgreSQL** database, exposing endpoints for creating, listing, retrieving, and deleting tasks.

---

## 🚀 Features

- Create a new task containing:
  - `id` (auto-generated)
  - `title`
  - `description`
  - `status` (text field)
- Get all tasks
- Get a task by ID
- Delete a task
- Database connection with **PostgreSQL**
- CORS enabled for local and external clients
- Swagger documentation included for easy testing

---

## 🧩 Tech Stack

- **ASP.NET Core 8**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger / Swashbuckle**
- **CORS**
- **Visual Studio / VS Code compatible**

---

## 📁 Project Structure

```bash
TodoApi/
├── Controllers/
│   └── TaskController.cs
├── Models/
│   └── TaskModel.cs
├── Services/
│   └── TaskService.cs        # optional business logic layer
├── Data/
│   └── AppDbContext.cs
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── appsettings.Development.json   # ignored by git
├── appsettings.example.json       # template for setup
├── Program.cs
└── TodoApi.csproj
```

---

## ⚙️ Setup & Installation

### 1. Clone the repository

```bash
git clone https://github.com/yourusername/todo-api.git
cd todo-api
```

### 2. Create configuration file

Copy the example file and edit it with your local credentials:

```bash
cp appsettings.example.json appsettings.Development.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=TodoDb;Username=postgres;Password=yourpassword"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

---

### 3. Run database migrations (if using EF Core)

```bash
dotnet ef database update
```

Or manually create a `Tasks` table in PostgreSQL if you’re not using migrations.

---

### 4. Run the API

```bash
dotnet run
```

By default, the API runs at:

- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`

---

## 🌐 API Endpoints

| Method | Endpoint             | Description              |
|--------|----------------------|--------------------------|
| `GET`  | `/api/tasks`         | Get all tasks            |
| `GET`  | `/api/tasks/{id}`    | Get a specific task      |
| `POST` | `/api/tasks`         | Create a new task        |
| `DELETE` | `/api/tasks/{id}`  | Delete a task by ID      |

---

## 🧪 Testing the API

### ▶️ Using Swagger
Once the API is running, open your browser and go to:

```
https://localhost:5001/swagger
```

This page provides an interactive documentation where you can test all endpoints.

### ▶️ Using Insomnia / Postman

If you get an SSL error (e.g. “SSL peer certificate was not OK”), either:
- Disable certificate validation in Insomnia, or  
- Run your API via HTTP (`http://localhost:5000`), or  
- Trust the dev certificate:
  ```bash
  dotnet dev-certs https --trust
  ```

---

## 🧰 Useful Commands

| Command | Description |
|----------|-------------|
| `dotnet run` | Start the API |
| `dotnet build` | Build the project |
| `dotnet watch run` | Auto-reload on changes |
| `dotnet ef migrations add <Name>` | Add new EF Core migration |
| `dotnet ef database update` | Apply migrations |

---

## 🧑‍💻 Author

**Luca Schutzenhofer**  
Software Engineer & Architect — JavaScript & .NET ecosystems  
Passionate about knowledge, philosophy, and science.

---

## 🪪 License

This project is open source and available under the [MIT License](LICENSE).
