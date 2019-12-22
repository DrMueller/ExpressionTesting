using System;
using System.Linq.Expressions;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.Expressions.ExpressionTypes
{
    public class BinaryExpressionDescription : ExpressionDescription
    {
        public override string Description { get; } = "BinaryExpression";
        public override ConsoleKey Key { get; } = ConsoleKey.F2;

        public BinaryExpressionDescription(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }

        protected override string GetExample()
        {
            var binaryExpression =
                Expression.MakeBinary(
                    ExpressionType.Subtract,
                    Expression.Constant(53),
                    Expression.Constant(14));

            return binaryExpression.ToString();
        }

        protected override string GetExpressionDescription()
        {
            return @"
Definiert eine Binär-Expression, also eine Relation (Beziehung) zwischen zwei Expressions.
Nachfolgendes Beispiel definiert eine Substraktion von zwei Konstanten.";
        }
    }
}