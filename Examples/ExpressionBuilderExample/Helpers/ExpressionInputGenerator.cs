using DynamicExpressionBuilder.Enums;
using DynamicExpressionBuilder.Models;
using System.Collections.Generic;

namespace ExpressionBuilderExample.Helpers
{
    internal static class ExpressionInputGenerator
    {
        public static IList<ExpressionInput> GetExpressionInputList()
        {
            return new List<ExpressionInput>
            {
                new ExpressionInput
                {
                    Operand = QueryOperand.And, //First Item does not matter And or OR
                    Operation = Operation.Contains,
                    PropertyName = "Name",
                    Value = "Jack"
                },
                new ExpressionInput
                {
                    Operand = QueryOperand.And,
                    Operation = Operation.StringEquals, //Operation.Equals
                    PropertyName = "State",
                    Value = "FL"
                },
                new ExpressionInput
                {
                    Operand = QueryOperand.Or,
                    Operation = Operation.NotEquals,
                    PropertyName = "CrimeRecord",
                    Value = false
                }
            };
        }
    }
}
