# 📘 Project README  

## 📖 Overview  
This project is built using **Clean Architecture** with **CQRS pattern** on **.NET 8**.  
The main goal is to provide a modular, scalable, and maintainable backend solution for **Experience LLC**.  

---

## 🏗️ Project Layers  

The solution follows **Clean Architecture** principles and consists of:  

- **Domain Layer**  
  - Contains core business logic, entities, and interfaces.  
  - No external dependencies.  

- **Application Layer**  
  - Implements CQRS using **MediatR**.  
  - Handles business use cases (Commands & Queries).  
  - Includes **FluentValidation** for validation.  

- **Infrastructure Layer**  
  - Database context (EF Core).  
  - Implementations for repositories and external services.  
  - Handles persistence and external integrations.  

- **Presentation Layer (API)**  
  - ASP.NET Core Web API project.  
  - Provides endpoints for external clients.  
  - Configured with **Swagger** for documentation.  

---

## 🗄️ Database Setup  

You have two options for setting up the database:  

1. **Using the provided .bak file**  
   - Restore the database from the `.bak` file available [here](./Docs/ApplicantsDB).  

2. **Using EF Core migrations**  
   - Update the connection string in `src/Api/appsettings.json`.  
   - Run the following commands:  

   ```powershell
   cd src/Infrastructure
   dotnet ef database update
   ```
## Running the Project

```powershell
dotnet restore
dotnet run --project API
```   
## API Documentation
We have two options to test the Apis

1. **Using Swagger**
2. **From Postman**
    - download postman collection from [Here](./docs/Applicants%20Web%20API.postman_collection.json)
    - download the ENV file from [Here](./docs/Applicants-ENV.postman_environment.json)



## 🖥️ Client Project Setup

The frontend is built with **React 18**, **Vite**, **TypeScript**, **Ant Design (AntD)**, **Axios**, and **Zustand** for state management.

### 1. Install Dependencies

From the `Client` folder:

```bash
cd /web
npm install
npm run dev
```


### 2. Environment Variables

web/.env

contain the VITE_API_URL for the endpoints

     



