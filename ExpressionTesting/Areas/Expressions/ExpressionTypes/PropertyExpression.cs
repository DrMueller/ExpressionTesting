using System;
using System.Linq.Expressions;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.Expressions.ExpressionTypes
{
    public class PropertyExpression : ExpressionDescription
    {
        public override string Description { get; } = "PropertyExpression";
        public override ConsoleKey Key { get; } = ConsoleKey.F5;

        public PropertyExpression(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }

        protected override string GetExample()
        {
            var paramExpression = Expression.Parameter(typeof(int));

            var methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new[] { typeof(int) }),
                paramExpression);

            var lambda = Expression.Lambda<Action<int>>(methodCall, paramExpression);

            return lambda.ToString();
        }

        protected override string GetExpressionDescription()
        {
            return @"
Repräsentiert einen Parameter.
Diese Expressions werden bei Lambdas oft mindestens zweimal verwendet: Einmal als Aufruf und einmal als Argument bei der Lammbda selber.
";
        }
    }
}