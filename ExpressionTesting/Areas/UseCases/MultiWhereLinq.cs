using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.UseCases
{
    public class MultiWhereLinq : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;

        public string Description { get; } = "LINQ OrElse";

        public ConsoleKey Key { get; } = ConsoleKey.D3;

        public MultiWhereLinq(IConsoleWriter consoleWriter)
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

            var wordEqualsWorld = Expression.MakeBinary(
                ExpressionType.Equal,
                strParam,
                Expression.Constant("World"));

            var wordEqualsTra = Expression.MakeBinary(
                ExpressionType.Equal,
                strParam,
                Expression.Constant("Tra"));

            var worldOrTra = Expression.OrElse(wordEqualsWorld, wordEqualsTra);
            var lambda = Expression.Lambda<Func<string, bool>>(worldOrTra, strParam);
            var comp = lambda.Compile();

            var foundWords = strCollection.Where(comp);
            _consoleWriter.WriteLine($"Found: {string.Join(", ", foundWords)}");
            return Task.CompletedTask;
        }
    }
}