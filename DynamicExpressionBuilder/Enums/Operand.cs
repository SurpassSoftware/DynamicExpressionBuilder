namespace DynamicExpressionBuilder.Enums
{

    /// <summary>
    /// Expression query operands
    /// </summary>
    public enum Operand
    {
        /// <summary>
        /// Equiavlent to &amp;&amp;
        /// </summary>
        And,

        /// <summary>
        /// Equiavlent to ||
        /// </summary>
        Or,

        /// <summary>
        /// Not should be equivalent to &amp;&amp; but operation should be use Operation.NotEquals
        /// </summary>
        Not
    }
}
