﻿namespace DynamicExpressionBuilder.Enums
{
    /// <summary>
    /// Linq operations
    /// </summary>
    public enum Operation
    {

        /// <summary>
        /// Linq Equivalent to == (for string)
        /// </summary>
        Equals,
        

        /// <summary>
        /// Linq Equivalent to !=
        /// </summary>
        NotEquals,


        /// <summary>
        /// Linq Equivalent to >
        /// </summary>
        GreaterThan,


        /// <summary>
        /// Linq Equivalent to &lt;
        /// </summary>
        LessThan,


        /// <summary>
        /// Linq Equivalent to >=
        /// </summary>
        GreaterThanOrEqual,


        /// <summary>
        /// Linq Equivalent to &lt;=
        /// </summary>
        LessThanOrEqual,


        /// <summary>
        /// Linq Equivalent to .Contains("")
        /// </summary>
        Contains,


        /// <summary>
        /// Linq Equivalent to .Contains("").ToLower()
        /// </summary>
        ContainsWithToLower,

        /// <summary>
        /// Linq Equivalent to ToString().Contains("")
        /// </summary>
        ToStringWithContains,


        /// <summary>
        /// Linq Equivalent to .StartsWith("")
        /// </summary>
        StartsWith,

        /// <summary>
        /// Linq Equivalent to .EndsWith("")
        /// </summary>
        EndsWith,

        /// <summary>
        /// Linq Equivalent to .ToLower().StartsWith("")
        /// </summary>
        StartsWithToLower,

        /// <summary>
        /// Linq Equivalent to .ToLower().EndsWith("")
        /// </summary>
        EndsWithToLower,

        /// <summary>
        /// Equivalent to .Compare(Property, PropertyInstring, OrdinalIgnoreCase) == 0
        /// </summary>
        StringEquals
    }
}
