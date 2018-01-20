using DynamicExpressionBuilder.Enums;

namespace DynamicExpressionBuilder.Models
{
    public class ExpressionInput
    {
        public string PropertyName { get; set; }

        public Operation Operation { get; set; }

        public object Value { get; set; }

        public QueryOperand Operand { get; set; }
    }
}
