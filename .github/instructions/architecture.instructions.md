---
applyTo: "**"
---

# Architecture Guidelines

This project follows a **Clean Architecture** approach with clear separation of concerns across layers.

## Layer Structure

### Domain (`ProjectTracker/Domain/`)
- Contains core business entities (e.g. `ProjectItem`, `AppUser`).
- Has **no dependencies** on other layers or external frameworks.
- Entities are plain C# classes with no persistence or framework annotations.

### Application (`Application/`)
- Contains business logic in **service classes** (e.g. `ProjectService`).
- Defines **abstractions** (interfaces) for infrastructure concerns such as repositories (e.g. `IProjectRepository`, `IUserRepository`).
- Depends only on the Domain layer.
- Returns `ValidationResult` for operation outcomes rather than throwing exceptions for expected failures.

### Infrastructure (`ProjectTracker/Infrastructure/`)
- Implements the interfaces defined in the Application layer (e.g. `InMemoryProjectRepository`).
- Handles data persistence, external services, and other technical concerns.
- Should never be referenced directly by Application or Domain layers.

### Presentation (`ProjectTracker/Controllers/`, `ProjectTracker/Views/`, `ProjectTracker/Models/`)
- ASP.NET Core MVC controllers, Razor views, and view models.
- Controllers are thin — they delegate business logic to Application services.
- View models live in `ProjectTracker/Models/` and are specific to the UI layer.

## Dependency Flow

```
Presentation → Application → Domain
Infrastructure → Application (implements interfaces)
```

- Dependencies point **inward** — outer layers depend on inner layers, never the reverse.
- The Application layer defines abstractions; Infrastructure provides implementations.
- Dependency injection is configured in `Program.cs`.

## Key Conventions

- Register services in `Program.cs` using the built-in DI container.
- Use **constructor injection** for all dependencies.
- Repositories are registered as singletons (in-memory); services as scoped.
- Keep controllers focused on HTTP concerns (model binding, redirects, view selection) — not business rules.
