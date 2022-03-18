using System;
using System.Collections.Generic;

namespace MultiValueDictionary.Services
{
    public interface IDictionaryManager
    {
        HashSet<Tuple<string, string>> GetDictionary();

        string AddToDictionary(string key, string value);

        string RemoveFromDictionary(string key, string value);

        List<string> GetDictionaryKeys();

        void ClearDictionary();

        bool GetMemberExists(string key, string value);

        bool GetKeyExists(string key);

        List<string> GetDictionaryMembers(string key);
    }
}
