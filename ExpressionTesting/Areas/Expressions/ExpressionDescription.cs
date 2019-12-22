using System;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.Expressions
{
    public abstract class ExpressionDescription : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;

        protected ExpressionDescription(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            var description = Description + ": " + GetExpressionDescription();
            _consoleWriter.WriteLine(description);
            _consoleWriter.WriteLine(GetExample());

            _consoleWriter.WriteLine(string.Empty);

            return Task.CompletedTask;
        }

        protected abstract string GetExpressionDescription();

        protected abstract string GetExample();

        public abstract string Description { get; }
        public abstract ConsoleKey Key { get; }
    }
}
