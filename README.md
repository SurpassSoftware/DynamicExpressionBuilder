## Overview
Simple C# expression builder at run-time.
Currently supports these operations:
```csharp
public enum Operation
    {
        Equals,
        LongEquals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        ContainsWithToLower,
        ToStringWithContains,
        StartsWith,
        EndsWith,
        StringEquals
    }
```

## Implementation
Steps:
+ Build expression input list
```csharp
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
                },
                new ExpressionInput
                {
                    Operand = QueryOperand.And,
                    Operation = Operation.GreaterThanOrEqual,
                    PropertyName = "AnnualIncome",
                    Value = (double)500000 //Value need to be parsed to Expression's object (T) type. Here T is of Citizen type and AnnualIncome is of double type.
                }
            };
        }
```
+ Passed to ExpressionBuilder
```csharp
            var expressionList = ExpressionInputGenerator.GetExpressionInputList();

            var expression = DynamicExpressionBuilder.ExpressionBuilder.GetExpression<Citizen>(expressionList); //Passing to expression builder. Here we are getting expression of Type Citizen
            Console.WriteLine($"Final Expression = {expression.ToString()}");
```
Output: `Final Expression = t => (((t.Name.Contains("Jack") AndAlso (Compare(t.State, "FL", OrdinalIgnoreCase) == 0)) Or (t.CrimeRecord != False)) AndAlso (t.AnnualIncome >= 500000))`
+ Using Final expression
```csharp
            var citizenRecords = CitizenRecordGenerator.GetCitizenRecordList();
            var expression = DynamicExpressionBuilder.ExpressionBuilder.GetExpression<Citizen>(expressionList)

            var filterCitizens = citizenRecords.Where(expression.Compile()); //Expression Implementation
            Console.WriteLine($"\nFilter records: {filterCitizens.Count()}");
```

## Conclusion

Above code are from example console app which is inside project.


