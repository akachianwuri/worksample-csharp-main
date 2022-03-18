using MultiValueDictionary.Services;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace MultiValueDictionaryTests
{
    public class DictionaryManagerTests
    {
        private IDictionaryManager _dictionaryManager;

        [SetUp]
        public void Setup()
        {
            _dictionaryManager = new DictionaryManager();
        }

        [Test]
        public void AddToDictionary_ShouldAddMemberToDictionary()
        {
            // Arrange
            var key = "foo";
            var value = "bar";

            // Act
            _dictionaryManager.AddToDictionary(key, value);
            var members = _dictionaryManager.GetDictionaryMembers(key);

            // Assert
            members.First().ShouldBe(value);
            members.Count.ShouldBe(1);
        }
    }
}
