# .NET 10 Web API with Hexagonal Architecture
.NET 10 Web API example built with hexagonal architecture (ports and adapters). It includes unit, integration and architectural tests together with cosole a aplication. This architecture helps to visualize the solution global workflow because it is implicit in its organization.

## About the solution
Below is a concise summary of what each project in the solution is responsible for.

### NetCoreHexagonal.Domain.csproj:
Core domain layer: entities, value objects, domain rules and domain-specific types. Framework- and persistence-agnostic.

### NetCoreHexagonal.Application.csproj
Application layer: ports (in/out) interfaces, DTOs, and service orchestration (use cases). Depends on domain types and exposes abstractions consumed by adapters.

### NetCoreHexagonal.Persistence.csproj
Persistence adapter: EF Core dbContext (e.g., SchoolDbContext), repository implementations, migrations and appsettings.json for DB connection. References Application and Domain and uses Microsoft.EntityFrameworkCore.SqlServer.

### NetCoreHexagonal.EventsDispatching.csproj
Events-dispatching adapter: concrete implementation(s) for publishing domain/application events. Plugs into the application layer event ports.

### NetCoreHexagonal.Console.csproj
Console presentation adapter: Program.cs that wires DI, configures services (application, persistence, events), seeds/demo data and exercises ISchoolService. Useful for manual/run-time demos.

### NetCoreHexagonal.WebApi.csproj
Web API presentation adapter: ASP.NET Core Web API project exposing REST endpoints, Swagger (Swashbuckle) and wiring the same adapters (persistence/events) and application services for HTTP clients.

### NetCoreHexagonal.ArchitectureTests.csproj
Architecture rules tests using NetArchTest.Rules to assert allowed project dependencies and architecture constraints.

### NetCoreHexagonal.UnitTests.csproj
Unit tests (xUnit) for application-level logic and small units; references the Application project.

### NetCoreHexagonal.IntegrationTests.csproj
Integration tests that exercise the persistence layer (references the Persistence project), include runtime configuration and resiliency packages (e.g., Polly) where needed.


## Notes

- All projects target net10.0 (C# 14.0 in solution context).
- Typical dependencies: EF Core (Persistence), Swashbuckle (WebApi), NetArchTest + xUnit (tests).
