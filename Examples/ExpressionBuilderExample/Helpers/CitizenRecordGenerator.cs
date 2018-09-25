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
                    Id = 1,
                    CrimeRecord = true,
                    Name = "Janak",
                    State = "CA",
                    AnnualIncome = 100000
                },
                new Citizen
                {
                    Id = 2,
                    CrimeRecord = true,
                    Name = "Jack",
                    State = "FL",
                    AnnualIncome = 50000
                }
            };
        }

    }
}
