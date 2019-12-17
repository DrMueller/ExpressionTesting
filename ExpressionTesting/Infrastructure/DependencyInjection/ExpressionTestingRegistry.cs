using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using StructureMap;

namespace ExpressionTesting.Infrastructure.DependencyInjection
{
    public class ExpressionTestingRegistry : Registry
    {
        public ExpressionTestingRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ExpressionTestingRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();

                    scanner.WithDefaultConventions();
                });
        }
    }
}