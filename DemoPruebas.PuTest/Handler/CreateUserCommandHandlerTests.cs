using DemoPruebas.Application.Commands;
using DemoPruebas.Application.Commands.Handlers;
using DemoPruebas.Application.Interfaces.Repositories;
using DemoPruebas.Application.Interfaces.RequestIntefaces;
using DemoPruebas.Application.Interfaces.Validations;
using DemoPruebas.Domain.Models;
using Moq;
using Xunit;

namespace DemoPruebas.UnitTests.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<ISqlRepository<Users, string>> _repositoryMock;
        private readonly Mock<ICreateUserValidations> _validationMock;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _repositoryMock = new Mock<ISqlRepository<Users, string>>();
            _validationMock = new Mock<ICreateUserValidations>();

            _handler = new CreateUserCommandHandler(
                _repositoryMock.Object,
                _validationMock.Object
            );
        }

        [Fact]
        public async Task Handle_Should_Create_User_Successfully()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Name = "John Doe",
                Email = "john@mail.com",
                Number = "12345",
                Status_Id = 1
            };

            _validationMock
                .Setup(v => v.ValidAsync(command.Name, command.Email, command.Number))
                .Returns(Task.CompletedTask);

            _repositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Users>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.Equal("John Doe", result.Data.Name);
            Assert.Equal("john@mail.com", result.Data.Email);
            Assert.Equal("12345", result.Data.Phone);
            Assert.Equal(1, result.Data.Status_Id);
            Assert.False(string.IsNullOrEmpty(result.Data.Id));

            _validationMock.Verify(v =>
                v.ValidAsync(command.Name, command.Email, command.Number),
                Times.Once);

            _repositoryMock.Verify(r =>
                r.CreateAsync(It.IsAny<Users>()),
                Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Throw_When_Validation_Fails()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Name = "ErrorUser",
                Email = "invalid",
                Number = "000",
            };

            _validationMock
                .Setup(v => v.ValidAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new Exception("Validation failed"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _handler.Handle(command, CancellationToken.None));

            _repositoryMock.Verify(r =>
                r.CreateAsync(It.IsAny<Users>()),
                Times.Never);
        }

        [Fact]
        public async Task Handle_Should_Throw_When_Repository_Fails()
        {
            // Arrange
            var command = new CreateUserCommand
            {
                Name = "Test",
                Email = "test@mail.com",
                Number = "999"
            };

            _validationMock
                .Setup(v => v.ValidAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            _repositoryMock
                .Setup(r => r.CreateAsync(It.IsAny<Users>()))
                .ThrowsAsync(new Exception("DB Error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() =>
                _handler.Handle(command, CancellationToken.None));

            _validationMock.Verify(v =>
                v.ValidAsync(command.Name, command.Email, command.Number),
                Times.Once);
        }
    }
}
