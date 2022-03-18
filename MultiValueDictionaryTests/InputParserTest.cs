using MultiValueDictionary.Services;
using NUnit.Framework;
using Shouldly;

namespace MultiValueDictionaryTests
{
    public class InputParserTests
    {
        private IInputParser _inputParser;

        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
        }

        [Test]
        public void ParseInput_ShouldReturnStringList()
        {
            // Arrange
            var input = "TEST foo bar";

            // Act
            var result = _inputParser.ParseInput(input);

            // Assert
            result.Count.ShouldBe(3);
        }
    }
}