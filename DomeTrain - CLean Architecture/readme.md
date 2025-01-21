This proect is not completed but done to be familar with DDD pattern.

CQRS pattern -> installed mediatR library in application layer and registered it, IRequest and IRequestHandler in implementation, child interface ISender was used following Liskov Substitution Principle

Result pattern -> installed ErrorOr package and in case of any error, ErrorOr has multiple method which will work as wrapper for problem and in case of success, simply result is returned.

Repository pattern -> an illusion as if we are working with object memory when behind it is working with some persistent solution.

UnitOfWork pattern ->

Clean Architecture -> architectural patter to split the system into different logical component which will have well defined interaction.

DDD-> approach for designing complex system, guideline, terminology to break up into small component to develop domain layer. Modeling according to domain.

Domain model -> object that contains both property and behaviour. Gym domain model containing both data (to check duplicacy) and behaviour (to add or remove).

    Anemic domain model -> expose data and rely on external manipulation on this data. A private list is manipulated by some external function.
    Rich domain model -> contains both the data and its behaviour, expose only some method to manipulate that data.

    Make all the fields and property to private and readonly by default.
    Expose only when needed.
    Expose only whats needed.

    Always valid domain model model
    Not always valid domain model model

Persistence Ignorance -> Modeling he domain without taking into account how the domain object will be persisted
