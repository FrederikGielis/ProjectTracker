# ProjectTracker workshop notes

This codebase is intentionally imperfect to support AI-assisted coding exercises.

## Current flow

1. Web layer: `ProjectsController` accepts add/delete/get-users requests.
2. Application layer: `ProjectService` coordinates use-cases.
3. Infrastructure layer: in-memory repositories store data.
4. Domain layer: entities represent `ProjectItem` and `AppUser`.

## Intentional shortcomings (for demo tasks)

- Domain entities are anemic and fully mutable.
- Business validation is weak and scattered.
- Repositories return mutable lists directly.
- In-memory storage is not thread-safe.
- Service uses potentially fragile string case logic.
- Controller mostly redirects instead of returning richer feedback.
- No unit/integration tests yet.

These issues are deliberate so you can demonstrate Copilot workflows such as refactoring, bug fixing, and explaining code changes.
