using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.UseCases
{
    public class DynamicStringContainsLinq : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;

        public string Description { get; } = "LINQ Contains String";

        public ConsoleKey Key { get; } = ConsoleKey.D2;

        public DynamicStringContainsLinq(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            var strCollection = new List<string>
            {
                "Hello",
                "World",
                "Olla",
                "Tra",
                "Hello Again"
            };

            var strParam = Expression.Parameter(typeof(string));

            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant("l", typeof(string));

            // So we're calling 'Contains' on the parametter string with the defined value
            // Aka: str.Contains(l)
            var containsMethodExp = Expression.Call(strParam, method, someValue);
            var containsLambda = Expression.Lambda<Func<string, bool>>(containsMethodExp, strParam);

            var comp = containsLambda.Compile();
            var allStringsWithL = strCollection.Where(comp);

            _consoleWriter.WriteLine($"Following strings contains an 'l': {string.Join(',', allStringsWithL)}");

            return Task.CompletedTask;
        }
    }
}