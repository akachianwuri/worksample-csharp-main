using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Services
{
    public class InputParser : IInputParser
    {
        public IList<string> ParseInput(string input)
        {
            return input.Split(' ').ToList();
        }
    }
}
