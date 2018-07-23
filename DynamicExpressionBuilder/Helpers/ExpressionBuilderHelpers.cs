using DynamicExpressionBuilder.Enums;
using DynamicExpressionBuilder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicExpressionBuilder.Helpers
{

    /// <summary>
    /// Contains helper methods
    /// </summary>
    public class ExpressionBuilderHelpers
    {

        /// <summary>
        /// Prepare ExpressionInput object. You can build your own logic to create ExpressionInput object.
        /// </summary>
        /// <param name="propertyName">Property Name</param>
        /// <param name="operation">Operation. Eg. .StartsWith(""), .Contains("")</param>
        /// <param name="value">Value to operate with</param>
        /// <param name="operand">Operand. And, Or, Not</param>
        /// <returns></returns>
        public static ExpressionInput GetExpressionInput(string propertyName, Operation operation, object value, Operand operand)
        {
            if (operand == Operand.Not)
                return new ExpressionInput { Value = value, Operand = Operand.And, Operation = Operation.NotEquals, PropertyName = propertyName };
            else
                return new ExpressionInput { Value = value, Operand = operand, Operation = operation, PropertyName = propertyName };

        }
    }
}
