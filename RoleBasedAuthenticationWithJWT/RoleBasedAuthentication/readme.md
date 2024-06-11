Implemented rolebased authentication with the help of jwt

firstly created a database User(string UserName,string Name,List<string>? Roles,bool IsActive,string? Token,string Password)

Role of type list was implemented with the help of entity framework's fluent api in order to store multiple role for user

While saving password, it was hashed by the help of Argon2 library

While creating token, we hashed the password entered by user during login process, and compared with database result,and on verifying them, a token was granted

Similarly, a field was added in swagger by writing some code in the program cs with the service named as `AddSwaggerGen` in order to get the authentication header, we passed `Bearer {token}` to the field in order to acces the role based controller, Similarly, role was assigned by user while creating the user.

jwt config was registered in program.cs
claims are the core information for jwt token, or simply they are the [critical] information to be hidden or extracted
Login method inside of Auth service has the logic for the token generation.
