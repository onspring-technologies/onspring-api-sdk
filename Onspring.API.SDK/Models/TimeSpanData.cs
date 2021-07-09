using Onspring.API.SDK.Enums;
using System;

namespace Onspring.API.SDK.Models
{
    public class TimeSpanData
    {
        public decimal Quantity { get; set; }

        public TimeSpanIncrement Increment { get; set; }

        public TimeSpanRecurrenceType Recurrence { get; set; }

        public DateTime? EndByDate { get; set; }

        public int? EndAfterOccurrences { get; set; }
    }
}
