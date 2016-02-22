using System;

namespace Onspring.API.SDK.ResultValues
{
    public class ScoringGroup
    {
        public Guid ListValueId { get; set; }

        public string Name { get; set; }

        public decimal Score { get; set; }

        public decimal MaximumScore { get; set; }

    }

}