---
applyTo: "**/*.cs"
---

# C# Code Conventions

## Naming

- **PascalCase** for classes, methods, properties, and public fields.
- **camelCase** for local variables and parameters.
- Prefix private fields with `_` (e.g. `_projectRepository`).
- Use descriptive, meaningful names — avoid abbreviations.
- Interface names start with `I` (e.g. `IProjectRepository`).

## File & Type Organisation

- One class/record/interface per file.
- File name must match the type name.
- Use file-scoped namespaces (`namespace X;` instead of `namespace X { }`).

## Formatting

- Use 4-space indentation (no tabs).
- Place opening braces on their own line (Allman style).
- Keep methods short and focused — aim for a single responsibility.

## Language Features

- Use `var` when the type is obvious from the right-hand side.
- Prefer `string.IsNullOrWhiteSpace` over manual null/empty checks.
- Use collection expressions and LINQ where it improves readability.
- Use records for simple data transfer objects (e.g. request/response models).
- Use nullable reference types — avoid `null` where possible.

## Error Handling

- Return `ValidationResult` from service methods for expected validation failures.
- Use exceptions only for unexpected/exceptional situations.
- Never swallow exceptions silently.

## ASP.NET MVC

- Keep controllers thin — delegate logic to Application services.
- Use `[HttpGet]`, `[HttpPost]`, and `[ValidateAntiForgeryToken]` attributes explicitly.
- Use strongly-typed view models rather than `ViewBag`/`ViewData` for passing data to views.
- Return `IActionResult` from all controller actions.
