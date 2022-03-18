using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Services
{
    public interface IInputParser
    {
        IList<string> ParseInput(string input);
    }
}
