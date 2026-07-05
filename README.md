# 🔐 Blazor Role-Based Authentication

A full-stack authentication and authorization system built with **ASP.NET Core Web API**, **Blazor**, **Entity Framework Core**, and **SQL Server**.

The project demonstrates secure authentication using JWT Access Tokens and Refresh Tokens, along with role-based authorization for Admin and User roles.

---

## 🚀 Features

- ✅ User Registration
- ✅ Secure Password Hashing
- ✅ User Login
- ✅ JWT Access Token Authentication
- ✅ Refresh Token Implementation
- ✅ Automatic Token Refresh
- ✅ Protected APIs
- ✅ Role-Based Authorization
- ✅ Admin Only Access
- ✅ Blazor Authentication State
- ✅ Protected Blazor Pages
- ✅ Role-Based Navigation
- ✅ Logout

---

## 🛠️ Tech Stack

### Backend

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Refresh Tokens
- Dependency Injection

### Frontend

- Blazor
- HttpClient
- AuthenticationStateProvider
- Protected Routes

---

## 👥 User Roles

### Admin

- Login
- Access Admin Dashboard
- Access Admin Pages
- Manage Protected Resources

### User

- Register
- Login
- Access User Dashboard
- View Authorized Pages

---

## 🔄 Authentication Flow

```text
Login
    │
    ▼
Generate JWT Access Token
    │
Generate Refresh Token
    │
Store Tokens
    │
Access Protected APIs
    │
Access Token Expires
    │
Use Refresh Token
    │
Generate New Access Token
```

---

## 📂 Project Structure

```text
Blazor-Role-Based-Authentication
│
├── Backend
│   ├── Controllers
│   ├── Services
│   ├── Models
│   ├── Repositories
│   ├── Data
│   └── Authentication
│
└── Frontend
    ├── Pages
    ├── Components
    ├── Services
    └── Authentication
```

---

## 🔐 Authorization

| Role | Access |
|------|--------|
| Admin | Admin Dashboard + Protected APIs |
| User | User Dashboard |

---

## 📚 Learning Objectives

This project demonstrates:

- JWT Authentication
- Refresh Token Flow
- Secure Password Hashing
- Role-Based Authorization
- Protected APIs
- Protected Blazor Pages
- Authentication State Management
- Full-Stack Communication
- REST API Integration

---

## 📄 License

This project is created for learning and portfolio purposes.
