using Microsoft.Extensions.DependencyInjection;
using MultiValueDictionary.Services;
using System;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDictionaryManager, DictionaryManager>()
                .AddTransient<ICommandService, CommandService>()
                .AddTransient<IInputValidator, InputValidator>()
                .AddTransient<IInputParser, InputParser>()
                .AddTransient<IMultiValueDictionaryService, MultiValueDictionaryService>()
                .BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IMultiValueDictionaryService>();

            while (true)
            {
                Console.Write(">");
                string input = Console.ReadLine();

                service.ProcessInput(input);
            }
        }
    }
}
