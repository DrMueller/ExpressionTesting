using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.ExpressionTypes
{
    public class BinaryExpressionDescription : ExpressionDescription
    {
        protected override string GetExpressionDescription()
        {
            return "Definiert eine Binär-Expression, also eine Relation (Beziehung) zwischen zwei Expressions. Nachfolgendes Beispiel definiert eine Substraktion von zwei Konstanten.";
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

        public override string Description { get; } = "BinaryExpression";
        public override ConsoleKey Key { get; } = ConsoleKey.F2;

        public BinaryExpressionDescription(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }
    }
}