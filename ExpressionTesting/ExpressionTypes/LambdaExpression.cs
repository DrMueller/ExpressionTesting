using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionTesting.ExpressionTypes
{
    class LambdaExpression
    {
        public void Tra()
        {
        Expression<Func<int, bool>> exprTree = num => num < 5;

        // Decompose the expression tree.  
        var param = (ParameterExpression)exprTree.Parameters[0];
        var operation = (BinaryExpression)exprTree.Body;
        var left = (ParameterExpression)operation.Left;
        var right = (ConstantExpression)operation.Right;

        Console.WriteLine("Decomposed expression: {0} => {1} {2} {3}",
                              param.Name, left.Name, operation.NodeType, right.Value);

            // This code produces the following output:  

            // Decomposed expression: num => num LessThan 5  

        }

    }
}
