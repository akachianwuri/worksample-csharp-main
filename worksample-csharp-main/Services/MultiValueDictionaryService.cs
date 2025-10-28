using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Services
{
    internal class MultiValueDictionaryService : IMultiValueDictionaryService
    {
        private readonly IInputParser _inputParser;
        private readonly IInputValidator _inputValidator;
        private readonly ICommandService _commandService;

        public MultiValueDictionaryService(IInputParser inputParser, IInputValidator inputValidator, ICommandService commandService)
        {
            _inputParser = inputParser;
            _inputValidator = inputValidator;
            _commandService = commandService;
        }

        public void ProcessInput(string input)
        {
            try
            {
                //parse input
                var inputList = _inputParser.ParseInput(input).ToList();

                //validate input
                var validationError = _inputValidator.Validate(inputList);

                if (!string.IsNullOrEmpty(validationError))
                {
                    //display output
                    Console.WriteLine(validationError);
                    return;
                }

                //process command
                var functions = new Dictionary<string, Func<List<string>, List<string>>>
                {
                    { "KEYS", (p) => _commandService.ProcessKeysCommand() },
                    { "MEMBERS", (p) => _commandService.ProcessMembersCommand(p[0]) },
                    { "ADD",  (p) => _commandService.ProcessAddCommand(p[0], p[1]) },
                    { "REMOVE", (p) => _commandService.ProcessRemoveCommand(p[0], p[1]) },
                    { "REMOVEALL",  (p) => _commandService.ProcessRemoveAllCommand(p[0]) },
                    { "CLEAR",  (p) => _commandService.ProcessClearCommand() },
                    { "KEYEXISTS",  (p) => _commandService.ProcessKeyExistsCommand(p[0]) },
                    { "MEMBEREXISTS", (p) => _commandService.ProcessMemberExistsCommand(p[0], p[1]) },
                    { "ALLMEMBERS",  (p) => _commandService.ProcessAllMembersCommand() },
                    { "ITEMS",  (p) => _commandService.ProcessItemsCommand() },
                    { "INTERSECT", (p) => _commandService.ProcessIntersectCommand(p[0], p[1]) }
                };

                var results = new List<string>();
                var command = inputList.FirstOrDefault();
                var parameters = new List<string>();
                parameters.AddRange(inputList);
                parameters.RemoveAt(0);

                var functionExists = functions.TryGetValue(command, out var functionToRun);

                if (functionExists)
                {
                    results = functionToRun(parameters);
                }
                else
                {
                    results.Add(") Please enter valid command with parameters.");
                }

                //display output
                foreach (var item in results)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(") here was an error processing your command");
            }
        }
    }
}
