using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of <see cref="ScoringGroup"/>.
    /// </summary>
    public class ScoringGroupListFieldValue : RecordFieldValue
    {
        /// <summary>
        /// Gets or sets the field's value.
        /// </summary>
        public List<ScoringGroup> Value { get; set; } = new List<ScoringGroup>();

        /// <summary>
        /// Initializes a new instance of <see cref="ScoringGroupListFieldValue"/>.
        /// </summary>
        public ScoringGroupListFieldValue()
        {
            Type = Enums.ResultValueType.ScoringGroupList;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ScoringGroupListFieldValue"/>.
        /// </summary>
        public ScoringGroupListFieldValue(int fieldId, List<ScoringGroup> value) : this()
        {
            FieldId = fieldId;
            Value = value;
        }
    }
}
