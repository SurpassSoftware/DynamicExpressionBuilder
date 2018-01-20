using ExpressionBuilderExample.Helpers;
using ExpressionBuilderExample.Models;
using System;
using System.Linq;

namespace ExpressionBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var expressionList = ExpressionInputGenerator.GetExpressionInputList();
            var citizenRecords = CitizenRecordGenerator.GetCitizenRecordList();

            var expression = DynamicExpressionBuilder.ExpressionBuilder.GetExpression<Citizen>(expressionList);
            Console.WriteLine($"Final Expression = {expression.ToString()}");

            var filterCitizens = citizenRecords.Where(expression.Compile());
            Console.WriteLine($"\nFilter records: {filterCitizens.Count()}");

            Console.ReadLine();
        }
    }
}
