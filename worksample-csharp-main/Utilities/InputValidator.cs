using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Services
{
    public class InputValidator : IInputValidator
    {
        private readonly List<string> validCommands = new()
        {
            "KEYS",
            "MEMBERS",
            "ADD",
            "REMOVE",
            "REMOVEALL",
            "CLEAR",
            "KEYEXISTS",
            "MEMBEREXISTS",
            "ALLMEMBERS",
            "ITEMS",
            "INTERSECT"
        };

        public bool IsValidCommand(List<string> wordsEntered)
        {
            return validCommands.Contains(wordsEntered.First());
        }

        public string Validate(List<string> wordsEntered)
        {
            if (!wordsEntered.Any())
            {
                return ") Please enter input text.";
            }

            if (wordsEntered.Count > 3)
            {
                return ") Please enter valid command with parameters.";
            }

            if (!IsValidCommand(wordsEntered))
            {
                return ") Please enter a valid command.";
            }

            var parameters = new List<string>();
            parameters.AddRange(wordsEntered);
            parameters.RemoveAt(0);

            return ValidateCommandParameters(wordsEntered[0], parameters);
        }

        private static string ValidateCommandParameters(string command, List<string> parameters)
        {
            var functions = new Dictionary<string, Func<List<string>, string>>
            {
                { "KEYS", (p) => ValidateKeysCommand(p) },
                { "MEMBERS", (p) => ValidateMembersComand(p) },
                { "ADD",  (p) => ValidateAddCommand(p) },
                { "REMOVE", (p) => ValidateRemoveCommand(p) },
                { "REMOVEALL",  (p) => ValidateRemoveAllCommand(p) },
                { "CLEAR",  (p) => ValidateClearCommand(p) },
                { "KEYEXISTS",  (p) => ValidateKeyExistsCommand(p) },
                { "MEMBEREXISTS", (p) => ValidateMemberExistsCommand(p) },
                { "ALLMEMBERS",  (p) => ValidateAllMembersCommand(p) },
                { "ITEMS",  (p) => ValidateItemsCommand(p) },
                { "INTERSECT", (p) => ValidateIntersectCommand(p) }
            };

            var functionExists = functions.TryGetValue(command, out var functionToRun);

            if (functionExists)
            {
                return functionToRun(parameters);
            }

            return string.Empty;
        }

        private static string ValidateIntersectCommand(List<string> parameters)
        {
            if (parameters.Count != 2)
            {
                return ") Please enter a valid command with parameters.";
            }

            return string.Empty;
        }

        private static string ValidateClearCommand(List<string> parameters)
        {
            if (parameters.Any())
            {
                return ") Please enter a valid command with parameters.";
            }

            return string.Empty;
        }

        private static string ValidateItemsCommand(List<string> parameters)
        {
            if (parameters.Any())
            {
                return ") Please enter a valid command with parameters.";
            }

            return string.Empty;
        }

        private static string ValidateAllMembersCommand(List<string> parameters)
        {
            if (parameters.Any())
            {
                return ") Please enter a valid command with parameters.";
            }

            return string.Empty;
        }

        private static string ValidateMemberExistsCommand(List<string> parameters)
        {
            if (parameters.Count != 2)
            {
                return ") Please enter a valid command with parameters.";
            }

            return string.Empty;
        }

        private static string ValidateKeyExistsCommand(List<string> parameters)
        {
            if (parameters.Count != 1)
            {
                return ") Please enter a valid command with parameters.";
            }
            return string.Empty;
        }

        private static string ValidateRemoveAllCommand(List<string> parameters)
        {
            if (parameters.Count != 1)
            {
                return ") Please enter a valid command with parameters.";
            }
            return string.Empty;
        }

        private static string ValidateRemoveCommand(List<string> parameters)
        {
            if (parameters.Count != 2)
            {
                return ") Please enter a valid command with parameters.";
            }
            return string.Empty;
        }

        private static string ValidateAddCommand(List<string> parameters)
        {
            if (parameters.Count != 2)
            {
                return ") Please enter a valid command with parameters.";
            }
            return string.Empty;
        }

        private static string ValidateMembersComand(List<string> parameters)
        {
            if (parameters.Count != 1)
            {
                return ") Please enter a valid command with parameters.";
            }
            return string.Empty;
        }

        private static string ValidateKeysCommand(List<string> parameters)
        {
            if (parameters.Any())
            {
                return ") Please enter a valid command with parameters.";
            }

            return string.Empty;
        }
    }
}
