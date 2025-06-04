Vertical Slice architecture
- organize code into feature folders, each feature is encapsulated in single .cs file
- against clean/onion architecture
- aims to organize code around specific feature or use case
- feature is implemented across all layers of the sotware (ie. presentation to db)
- Divide applicaton into distinct feature of functionality

- Application is divided into feature based, independent slice

- Rapid developmment  

CQRS Pattern
- divide operation into command (write) and query (read)
- Logical implementation of CQRS -> Splitting operations(Read and write at code level) not database
- Physical implementation of CQRS -> Splitting operations (Read and write at code level) as well as database operations interact


Mediator Pattern
- obbject ineteration through 'mediator', reduces dependency and simplifies communicaton
- works between api and application (command handler)
- Controller receives a request, it creates a command or query object and sends it to MediatR. MediatR then dispatches this object to appropriate handler.
- also handling request require logging, vaidation, security check, that all ccan be handled by `MediatR pipeline behaviour`
- Wrap around the request handling, allowing us to execute logic before and after actual handler.

DI

Minimal APis

ORM


Library:
    - MediatR 
    - Carter (for api endpoints easier to define API endpoints and handling http request)
    - Marten (for PSQL interaction Document DB. enhances JSON cability for storing managing and querying documents)
    - Mapster (for object mapping)
    - FluentValidation

Carter -> wrap around minimal api