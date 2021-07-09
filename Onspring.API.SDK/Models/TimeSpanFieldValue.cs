namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a <see cref="TimeSpanData"/>.
    /// </summary>
    public class TimeSpanFieldValue : RecordFieldValue<TimeSpanData>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TimeSpanFieldValue"/>.
        /// </summary>
        public TimeSpanFieldValue()
        {
            Type = Enums.ResultValueType.TimeSpan;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TimeSpanFieldValue"/>.
        /// </summary>
        public TimeSpanFieldValue(int fieldId, TimeSpanData value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
