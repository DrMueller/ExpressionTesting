using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.ExpressionTypes
{
    public class LambdaExpression : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        public string Description { get; } = "LambdaExpression";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public LambdaExpression(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            Expression<Func<int, bool>> exprTree = num => num < 5;

            // Decompose the expression tree.
            var param = exprTree.Parameters[0];
            var operation = (BinaryExpression)exprTree.Body;
            var left = (ParameterExpression)operation.Left;
            var right = (ConstantExpression)operation.Right;

            var description = $"Decomposed expression: {param.Name} => {left.Name} {operation.NodeType} {right.Value}";

            _consoleWriter.WriteLine(description);
            return Task.CompletedTask;
        }
    }
}