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
                    Operation = Operation.StartsWith,
                    PropertyName = "Name",
                    Value = "Jack"
                },
                new ExpressionInput
                {
                    Operand = Operand.And,
                    Operation = Operation.Equals,
                    PropertyName = "Id",
                    Value = 1
                },
                new ExpressionInput
                {
                    Operand = Operand.And,
                    Operation = Operation.Equals,
                    PropertyName = "State",
                    Value = "FL"
                },
                new ExpressionInput
                {
                    Operand = Operand.Or,
                    Operation = Operation.Equals,
                    PropertyName = "CrimeRecord",
                    Value = false
                },
                new ExpressionInput
                {
                    Operand = Operand.And,
                    Operation = Operation.Equals,
                    PropertyName = "AnnualIncome",
                    Value = (long)50000 //Value need to be parsed to Expression's object (T) type. Here T is of Citizen type and AnnualIncome is of double type.
                }
            };
        }
    }
}
