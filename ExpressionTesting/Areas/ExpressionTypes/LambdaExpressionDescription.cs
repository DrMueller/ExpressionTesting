using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.ExpressionTypes
{
    public class LambdaExpressionDescription : ExpressionDescription
    {
        private readonly IConsoleWriter _consoleWriter;

        protected override string GetExample()
        {
            Expression<Func<int, bool>> exprTree = num => num < 5;

            var param = exprTree.Parameters[0];
            var operation = (BinaryExpression)exprTree.Body;
            var left = (ParameterExpression)operation.Left;
            var right = (ConstantExpression)operation.Right;

            var description = $"Decomposed expression: {param.Name} => {left.Name} {operation.NodeType} {right.Value}";

            return exprTree.ToString();
        }

        public override string Description { get; } = "LambdaExpression";
        public override ConsoleKey Key { get; } = ConsoleKey.F1;

        protected override string GetExpressionDescription()
        {
            return "";
        }

        public LambdaExpressionDescription(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }
    }
}