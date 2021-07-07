using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Represents a field value comprised of a collection of <see cref="ScoringGroup"/> values.
    /// </summary>
    public class ScoringGroupListFieldValue : RecordFieldValue<List<ScoringGroup>>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ScoringGroupListFieldValue"/>.
        /// </summary>
        public ScoringGroupListFieldValue()
        {
            Type = Enums.ResultValueType.ScoringGroupList;
            Value = new List<ScoringGroup>();
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
