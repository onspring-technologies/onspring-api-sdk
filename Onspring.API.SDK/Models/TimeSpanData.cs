using Onspring.API.SDK.Enums;
using System;

namespace Onspring.API.SDK.Models
{
    public class TimeSpanData
    {
        public decimal Quantity { get; private set; }

        public TimeSpanIncrement Increment { get; private set; }

        public TimeSpanRecurrenceType Recurrence { get; private set; }

        public DateTime? EndByDate { get; protected set; }

        public int? EndAfterOccurrences { get; set; }
    }
}
