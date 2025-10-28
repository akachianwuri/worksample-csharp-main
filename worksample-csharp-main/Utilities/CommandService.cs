using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary.Services
{
    public class CommandService : ICommandService
    {

        private readonly IDictionaryManager _dictionaryManager;

        public CommandService(IDictionaryManager dictionaryManager)
        {
            _dictionaryManager = dictionaryManager;
        }

        public List<string> ProcessKeysCommand()
        {
            return _dictionaryManager.GetDictionaryKeys();
        }

        public List<string> ProcessMembersCommand(string key)
        {
            var members = _dictionaryManager.GetDictionaryMembers(key);

            if (!members.Any())
            {
                return new List<string> { ") ERROR, key does not exist." };
            }

            return members.AsEnumerable().Select((x, index) => $"{index + 1}) {x}").ToList();
        }

        public List<string> ProcessAddCommand(string key, string value)
        {
            return new List<string> { _dictionaryManager.AddToDictionary(key, value) };
        }

        public List<string> ProcessRemoveCommand(string key, string value)
        {
            return new List<string> { _dictionaryManager.RemoveFromDictionary(key, value) };
        }

        public List<string> ProcessRemoveAllCommand(string key)
        {
            var membersToBeRemoved = _dictionaryManager.GetDictionaryMembers(key);

            if (!membersToBeRemoved.Any())
            {
                return new List<string> { ") ERROR, key does not exist" };
            }

            foreach (var memberToBeRemoved in membersToBeRemoved)
            {
                _dictionaryManager.RemoveFromDictionary(key, memberToBeRemoved);
            }

            return new List<string> { ") Removed" };
        }

        public List<string> ProcessClearCommand()
        {
            _dictionaryManager.ClearDictionary();
            return new List<string> { ") Cleared" };
        }

        public List<string> ProcessKeyExistsCommand(string key)
        {
            return new List<string> { $") {_dictionaryManager.GetKeyExists(key).ToString().ToLowerInvariant()}" };
        }

        public List<string> ProcessMemberExistsCommand(string key, string value)
        {
            return new List<string> { $") {_dictionaryManager.GetMemberExists(key, value).ToString().ToLowerInvariant()}" };
        }

        public List<string> ProcessAllMembersCommand()
        {
            var members = _dictionaryManager.GetDictionary().Select(x => x.Item2).ToList();

            if (!members.Any())
            {
                return new List<string> { "(empty set)" };
            }

            return members;
        }

        public List<string> ProcessItemsCommand()
        {
            var members = _dictionaryManager.GetDictionary().Select(x => string.Format($"{x.Item1}: {x.Item2}"));

            if (!members.Any())
            {
                return new List<string> { "(empty set)" };
            }

            return members.ToList();
        }

        public List<string> ProcessIntersectCommand(string firstKey, string secondKey)
        {
            return _dictionaryManager.GetIntersect(firstKey, secondKey);
        }
    }
}
