# Project Task Management API

A simple Clean Architecture-based RESTful API built with ASP.NET Core for managing projects and tasks with JWT Authentication.

---

## Features

- User Authentication (Register / Login)
- JWT Token Authentication
- Projects Management (Create, Read, Update, Delete)
- Tasks Management inside Projects (Create, Read, Update, Delete)
- Each user manages only his own data
- Clean Architecture (Core / Data / Repository / Service / API)
- Entity Framework Core with SQL Server
- Repository + Unit of Work Pattern

---

## Architecture

ProjectTaskManagementAPI  
├── Core → Entities, DTOs, Interfaces  
├── Data → DbContext, EF Configurations  
├── Repository → Data Access Layer  
├── Service → Business Logic Layer  
└── API → Controllers  

---

## Authentication

This API uses JWT Bearer Token Authentication.

### Flow:
1. Register user
2. Login to get token
3. Use token in Authorization header

Authorization:
Bearer YOUR_TOKEN

---

## API Endpoints

### Authentication
POST /api/Authentication/register  
POST /api/Authentication/login  

### Projects
POST /api/Projects/CreateProject
GET /api/Projects/GetAllProject
GET /api/Projects/GetProjectById/{{projectId}}
PUT /api/Projects/UpdateProject/{{projectId}}
DELETE /api/Projects/DeleteProject/{{projectId}}

### Tasks
POST /api/Tasks/CreateTask  
GET /api/Tasks/GetTaskByProject/{projectId}  
PUT /api/Tasks/UpdateTaskStatus/{taskId}  
DELETE /api/Tasks/Deletetask/{taskId}  

---

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- C#
- LINQ
- Clean Architecture

---

## How to Run

1. Clone repo:
git clone https://github.com/USERNAME/ProjectTaskManagementAPI.git

2. Update connection string in appsettings.json

3. Run migrations:
dotnet ef database update

4. Run project:
dotnet run

---

## Notes

- This project is built for learning Clean Architecture
- Demonstrates real-world API structure
- Suitable for interview showcase
