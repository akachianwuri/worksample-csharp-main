using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary.Services
{
    public class DictionaryManager : IDictionaryManager
    {
        private readonly HashSet<Tuple<string, string>> _dictionary = new();

        public void ClearDictionary()
        {
            _dictionary.Clear();
        }

        public HashSet<Tuple<string, string>> GetDictionary()
        {
            return _dictionary;
        }

        public string AddToDictionary(string key, string value)
        {
            var itemInDictionary = GetItem(key, value);
            if (itemInDictionary != null)
            {
                return ") ERROR, member already exists for key";
            }

            _dictionary.Add(new Tuple<string, string>(key, value));

            return ") Added";
        }

        public string RemoveFromDictionary(string key, string value)
        {
            if (!KeyExists(key))
            {
                return ") ERROR, key does not exist";
            }

            var itemInDictionary = GetItem(key, value);

            if (itemInDictionary == null || !itemInDictionary.Item2.Equals(value))
            {
                return ") ERROR, member does not exist";
            }

            _dictionary.Remove(CreateTuple(key, value));

            return ") Removed";
        }

        public List<string> GetDictionaryKeys()
        {
            if (!_dictionary.Any())
            {
                return new List<string> { ") empty set" };
            }

            return _dictionary.AsEnumerable().Select((x, index) => $"{index+1}) {x.Item1}").ToList();
        }

        public List<string> GetDictionaryMembers(string key)
        {
            if (!_dictionary.Any())
            {
                return new List<string>();
            }

            return _dictionary.Where(x => x.Item1.Equals(key)).Select(y => y.Item2).ToList();
        }

        public bool GetMemberExists(string key, string value)
        {
            return GetItem(key, value) != null;
        }

        public bool GetKeyExists(string key)
        {
            return KeyExists(key);
        }

        private Tuple<string, string> GetItem(string key, string value)
        {
            _dictionary.TryGetValue(CreateTuple(key, value), out Tuple<string, string> item);

            return item;
        }

        private static Tuple<string, string> CreateTuple(string key, string value)
        {
            return new Tuple<string, string>(key, value);
        }

        private bool KeyExists(string key)
        {
            return _dictionary.Select(x => x.Item1).Contains(key);
        }
    }
}
