using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.Expressions.ExpressionTypes
{
    public class LambdaExpressionDescription : ExpressionDescription
    {
        public override string Description { get; } = "LambdaExpression";
        public override ConsoleKey Key { get; } = ConsoleKey.F1;

        public LambdaExpressionDescription(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }

        protected override string GetExample()
        {
            var paramExpr = Expression.Parameter(typeof(int), "arg");

            var lambdaExpr = Expression.Lambda(
                Expression.Add(
                    paramExpr,
                    Expression.Constant(1)),
                new List<ParameterExpression> { paramExpr });

            return lambdaExpr.ToString();
        }

        protected override string GetExpressionDescription()
        {
            var str = @"
Lambda-Expressions stellen eine anonyme Funktion dar.
Sie können implizit aus Lambdas erstellt werden, z.b. 'Expression<Func<int, bool>> exprTree = num => num < 5;'.
                
Lambda-Expressions bestehen immer aus einem Body und Parametern (wie normale Funktionen).
Folglich können Lambda-Expression Bodies auch wiederum aus beliebigen Expressions bestehen.

Author: Das ist wohl die Mutter aller Expressions, da jede Funktion mit dieser ausgedrück wird.

Siehe auch: https://docs.microsoft.com/en-us/dotnet/api/system.linq.expressions.lambdaexpression?view=netframework-4.8    
            ";

            return str;
        }
    }
}