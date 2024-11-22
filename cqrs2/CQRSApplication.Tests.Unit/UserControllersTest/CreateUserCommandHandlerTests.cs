using CQRSApplication.Command.AuthUserCommand;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CQRSApplication.Context;
using Moq;

namespace CQRSApplication.Test.UserControllersTest;
public class CreateUserCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnNewUser_WhenUserIsCreatedSuccessfully()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CQRSDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_CreateUser")
            .Options;

        using var dbContext = new CQRSDbContext(options);
        var mediatorMock = new Mock<IMediator>();

        var createUserCommand = new CreateUserCommand
        {
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "9898989898",
            Address = "123 Main St",
            UserCredentials = new CreateUserCredentials
            {
                UserName = "john.doe",
                Password = "password123",
                Email = "john.doe@example.com"
            },
            ShippingDetails = new ShippingDetails
            {
                City = "City",
                District = "District",
                StreetAddress = "123 Street"
            }
        };

        var handler = new CreateUserCommandHandler(dbContext, mediatorMock.Object);
        var cancellationToken = new CancellationToken();

        // Act
        var result = await handler.Handle(createUserCommand, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createUserCommand.FirstName, result.FirstName);
        //result.Should().BeOfType<CreateUserCommand>();
        Assert.Equal(createUserCommand.LastName, result.LastName);
    }
}