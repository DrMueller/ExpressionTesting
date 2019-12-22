using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using ExpressionTesting.Areas.UseCases;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace ExpressionTesting.Areas.Expressions.ExpressionTypes
{
    public class MethodCallExpression : ExpressionDescription
    {
        public override string Description { get; } = "MethodCall";
        public override ConsoleKey Key { get; } = ConsoleKey.F4;

        public MethodCallExpression(IConsoleWriter consoleWriter) : base(consoleWriter)
        {
        }

        protected override string GetExample()
        {
            var exampleForInstane = GetExampleForInstance();
            var exampleForStatic = GetExampleForStatic();

            var sb = new StringBuilder();
            sb.Append("Example for Instance call: ");
            sb.AppendLine(exampleForInstane);

            sb.Append("Example for Static call: ");
            sb.AppendLine(exampleForStatic);
            return sb.ToString();
        }

        protected override string GetExpressionDescription()
        {
            return $@"
Erlaubt einen Methodenaufruf auf eine statische oder Instanz-Methode, wobei nur genau Argument erlaubt ist.
Da der Aufruf auf eine beliebige Expression erfolgen kann, sind beliebige Kombinationen möglich.
Als Beispiel siehe auch {nameof(DynamicStringContainsLinq)}.;
";
        }

        private static string GetExampleForStatic()
        {
            var parseMethod = typeof(int)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(f => f.Name == nameof(int.Parse))
                .Single(f => f.GetParameters().Length == 1);

            var paramExpression = Expression.Parameter(typeof(string));
            var callOnInstance = Expression.Call(parseMethod, paramExpression);
            var lamba = Expression.Lambda<Func<string, int>>(callOnInstance, paramExpression);

            ////var actualWork = lamba.Compile().Invoke("1234");

            return lamba.ToString();
        }

        private static string GetExampleForInstance()
        {
            const string Hello = "Hello";
            var toUpperMethod = typeof(string).GetMethod("ToUpper", new List<Type>().ToArray());
            var constantExpression = Expression.Constant(Hello);

            var callOnInstance = Expression.Call(constantExpression, toUpperMethod);
            var lamba = Expression.Lambda<Func<string>>(callOnInstance);

            return lamba.ToString();
        }
    }
}