using Moq;
using MultiValueDictionary.Services;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace MultiValueDictionaryTests
{
    public class CommandServiceTests
    {
        private Mock<IDictionaryManager> _mockDictionaryManager;
        private ICommandService _commandService;

        [SetUp]
        public void Setup()
        {
            _mockDictionaryManager = new Mock<IDictionaryManager>(MockBehavior.Strict);
            _commandService = new CommandService(_mockDictionaryManager.Object);
        }

        [Test]
        public void ProcessKeysCommand_ShouldReturnAllDictionaryKeys()
        {
            // Arrange
            var keys = new List<string> { "foo", "bar" };

            _mockDictionaryManager.Setup(dm => dm.GetDictionaryKeys())
                .Returns(keys);

            // Act
            var results = _commandService.ProcessKeysCommand();

            // Assert
            results.ShouldBe(keys);
        }
    }
}
