using ExpressionBuilderExample.Models;
using System.Collections.Generic;

namespace ExpressionBuilderExample.Helpers
{
    internal static class CitizenRecordGenerator
    {

        public static IList<Citizen> GetCitizenRecordList()
        {
            return new List<Citizen>
            {
                new Citizen
                {
                    CrimeRecord = true,
                    Name = "Janak",
                    State = "CA",
                    AnnualIncome = 100000
                },
                new Citizen
                {
                    CrimeRecord = true,
                    Name = "Jack",
                    State = "FL",
                    AnnualIncome = 50000
                }
            };
        }

    }
}
