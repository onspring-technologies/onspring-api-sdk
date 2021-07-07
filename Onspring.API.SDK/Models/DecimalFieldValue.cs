namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a nullable decimal value.
    /// </summary>
    public class DecimalFieldValue : RecordFieldValue<decimal?>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="DecimalFieldValue"/>.
        /// </summary>
        public DecimalFieldValue()
        {
            Type = Enums.ResultValueType.Decimal;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DecimalFieldValue"/>.
        /// </summary>
        public DecimalFieldValue(int fieldId, decimal? value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
