Guiding Design Principle
- Seperation of concern
- Encapsulation
- Dependency Inversion
- Explicit dependencies
- Single responsibility
- DRY
- Persistence ignorance
- Bounded contexts
  

Domain Layer
- Entities
- Value object
- Domain events
- Domain services
- Interfaces
- Exceptions
- Enums

Application Layer
- Orchestrates the domain
- Contains the business logic
- Defines the Use case

Infrastructure Layer
- External services
  - Database
  - Messaging
  - Email providers
  - Storage services
  - Identity
  - System clock

Presentation layer
- RestApi
- Middleware
- DI setup


Things done in this project 
- CQRS pattern and MediatR
- Rich domain model and domain driven design
- Dapper to query data 
- Logging by injecting it to request pipeline with MediatR pipeline behaviour
- Fluent validation for validating dtos with 
- 