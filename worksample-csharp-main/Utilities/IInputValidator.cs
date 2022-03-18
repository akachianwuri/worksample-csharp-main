using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.Services
{
    public interface IInputValidator
    {
        bool IsValidCommand(List<string> wordsEntered);

        string Validate(List<string> wordsEntered);
    }
}
