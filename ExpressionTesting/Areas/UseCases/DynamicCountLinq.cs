using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.UseCases
{
    public class DynamicCountLinq : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        public string Description { get; } = "LINQ Count";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public DynamicCountLinq(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            const string TestString = "Hello World1234";

            // This example does the expression the count
            //// var lChars = TestString.Count(f => f == 'c');

            var paramExpression = Expression.Parameter(typeof(char), "arg");
            var constantExpression = Expression.Constant('l', typeof(char));
            var expression = Expression.MakeBinary(ExpressionType.Equal, paramExpression, constantExpression);

            var lambda = Expression.Lambda<Func<char, bool>>(expression, paramExpression);

            var lCharsCount = TestString.AsQueryable().Count(lambda);
            _consoleWriter.WriteLine($"Found {lCharsCount} 'l' chars in '{TestString}'");

            return Task.CompletedTask;
        }
    }
}