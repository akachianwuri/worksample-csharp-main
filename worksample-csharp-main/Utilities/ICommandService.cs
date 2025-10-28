using System.Collections.Generic;

namespace MultiValueDictionary.Services
{
    public interface ICommandService
    {
        List<string> ProcessKeysCommand();

        List<string> ProcessMembersCommand(string key);

        List<string> ProcessAddCommand(string key, string value);

        List<string> ProcessRemoveCommand(string key, string value);

        List<string> ProcessRemoveAllCommand(string key);

        List<string> ProcessClearCommand();

        List<string> ProcessKeyExistsCommand(string key);

        List<string> ProcessMemberExistsCommand(string key, string value);

        List<string> ProcessAllMembersCommand();

        List<string> ProcessItemsCommand();

        List<string> ProcessIntersectCommand(string firstKey, string secondKey);
    }
}
