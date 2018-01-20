using DynamicExpressionBuilder.Enums;

namespace DynamicExpressionBuilder.Models
{

    /// <summary>
    /// Expression Input model
    /// </summary>
    public class ExpressionInput
    {

        /// <summary>
        /// Property name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Expression Operantion
        /// </summary>
        public Operation Operation { get; set; }

        /// <summary>
        /// Value to operate
        /// </summary>
        public object Value { get; set; }


        /// <summary>
        /// Expression operand
        /// </summary>
        public QueryOperand Operand { get; set; }
    }
}
