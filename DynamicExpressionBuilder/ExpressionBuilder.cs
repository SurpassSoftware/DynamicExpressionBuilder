using DynamicExpressionBuilder.Enums;
using DynamicExpressionBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace DynamicExpressionBuilder
{

    /// <summary>
    /// Expression Builder
    /// </summary>
    public static class ExpressionBuilder
    {

        private static readonly MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
        private static readonly MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", new Type[0]);
        private static readonly MethodInfo toStringMethod = typeof(int).GetMethod("ToString", new Type[0]);
        private static readonly MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static readonly MethodInfo compareMethod = typeof(string).GetMethod("Compare", new Type[] { typeof(string), typeof(string), typeof(StringComparison) });

        /// <summary>
        /// Convert expression input to expression
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="filters">Expression input filters</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpression<T>(IList<ExpressionInput> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else
            {
                foreach (var filter in filters)
                {
                    if (exp == null)
                        exp = GetExpression<T>(param, filter);
                    else
                    {
                        if (filter.Operand == Operand.And)
                        {
                            var tempExp = GetExpression<T>(param, filter);
                            exp = Expression.AndAlso(exp, tempExp);
                        }
                        else //Default OR
                        {
                            var tempExp = GetExpression<T>(param, filter);
                            exp = Expression.Or(exp, tempExp);
                        }
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, ExpressionInput filter)
        {
            try
            {
                MemberExpression member = Expression.Property(param, filter.PropertyName);
                ConstantExpression constant = Expression.Constant(filter.Value);
                ConstantExpression stringComparisonConstant = Expression.Constant(StringComparison.OrdinalIgnoreCase);

                switch (filter.Operation)
                {
                    case Operation.Equals:
                        return Expression.Equal(member, constant);

                    case Operation.NotEquals:
                        return Expression.NotEqual(member, constant);

                    case Operation.GreaterThan:
                        return Expression.GreaterThan(member, constant);

                    case Operation.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(member, constant);

                    case Operation.LessThan:
                        return Expression.LessThan(member, constant);

                    case Operation.LessThanOrEqual:
                        return Expression.LessThanOrEqual(member, constant);

                    case Operation.Contains:
                        return Expression.Call(member, containsMethod, new[] { constant });

                    case Operation.ContainsWithToLower:
                        var toLowerMember = Expression.Call(member, toLowerMethod);
                        return Expression.Call(toLowerMember, containsMethod, constant);

                    case Operation.ToStringWithContains:
                        var tostringMember = Expression.Call(member, toStringMethod);
                        return Expression.Call(tostringMember, containsMethod, constant);

                    case Operation.StartsWith:
                        return Expression.Call(member, startsWithMethod, constant);

                    case Operation.EndsWith:
                        return Expression.Call(member, endsWithMethod, constant);

                    case Operation.StringEquals:
                        var zeroConstant = Expression.Constant(0);
                        var compareExpression = Expression.Call(compareMethod, member, constant, stringComparisonConstant);
                        return Expression.Equal(compareExpression, zeroConstant);
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
