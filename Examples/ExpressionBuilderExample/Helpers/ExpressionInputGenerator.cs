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
                    Operand = Operand.And, //First Item does not matter And or OR
                    Operation = Operation.Contains,
                    PropertyName = "Name",
                    Value = "Jack"
                },
                new ExpressionInput
                {
                    Operand = Operand.And,
                    Operation = Operation.StringEquals, //Operation.Equals
                    PropertyName = "State",
                    Value = "FL"
                },
                new ExpressionInput
                {
                    Operand = Operand.Or,
                    Operation = Operation.NotEquals,
                    PropertyName = "CrimeRecord",
                    Value = false
                },
                new ExpressionInput
                {
                    Operand = Operand.And,
                    Operation = Operation.GreaterThanOrEqual,
                    PropertyName = "AnnualIncome",
                    Value = (double)500000 //Value need to be parsed to Expression's object (T) type. Here T is of Citizen type and AnnualIncome is of double type.
                }
            };
        }
    }
}
