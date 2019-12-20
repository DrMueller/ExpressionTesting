﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.ExpressionTypes
{
    public class ConstantExpressionDescription : ExpressionDescription
    {
        public ConstantExpressionDescription(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }

        protected override string GetExpressionDescription()
        {
            return "Definiert einen konstanten Wert (const).";
        }

        protected override string GetExample()
        {
            var expr = Expression.Constant(5.5);
            return expr.ToString();
        }

        public override string Description { get; } = "ConstantExpression";
        public override ConsoleKey Key { get; } = ConsoleKey.F3;
    }
}
