namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a nullable int value.
    /// </summary>
    public class IntegerFieldValue : RecordFieldValue<int?>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="IntegerFieldValue"/>.
        /// </summary>
        public IntegerFieldValue()
        {
            Type = Enums.ResultValueType.Integer;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="IntegerFieldValue"/>.
        /// </summary>
        public IntegerFieldValue(int fieldId, int? value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
