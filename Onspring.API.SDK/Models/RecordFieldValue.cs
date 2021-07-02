#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Onspring.API.SDK.Enums;
using System;
using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    /// <summary>
    /// Wraps a result record value with its field id (used for enumerating all values)
    /// </summary>
    public class RecordFieldValue
    {
        public ResultValueType Type { get; set; }
        public int FieldId { get; set; }
    }

    /// <summary>
    /// Extensions around <see cref="RecordFieldValue"/>.
    /// </summary>
    public static class RecordFieldValueExtensions
    {
        /// <summary>
        /// Gets the string value by casting the <see cref="RecordFieldValue"/> to <see cref="StringFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.String"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static string AsString(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return default;
            }

            recordFieldValue.ValidateType(ResultValueType.String);

            return ((StringFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the nullable integer value by casting the <see cref="RecordFieldValue"/> to <see cref="IntegerFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.Integer"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static int? AsNullableInteger(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return default;
            }

            recordFieldValue.ValidateType(ResultValueType.Integer);

            return ((IntegerFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the nullable decimal value by casting the <see cref="RecordFieldValue"/> to <see cref="DecimalFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.Decimal"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static decimal? AsNullableDecimal(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return default;
            }

            recordFieldValue.ValidateType(ResultValueType.Decimal);

            return ((DecimalFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the nullable date value by casting the <see cref="RecordFieldValue"/> to <see cref="DateFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.Date"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static DateTime? AsNullableDateTime(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return default;
            }

            recordFieldValue.ValidateType(ResultValueType.Date);

            return ((DateFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the nullable Guid value by casting the <see cref="RecordFieldValue"/> to <see cref="GuidFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.Guid"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static Guid? AsNullableGuid(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return default;
            }

            recordFieldValue.ValidateType(ResultValueType.Guid);

            return ((GuidFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the <see cref="TimeSpanData"/> value by casting the <see cref="RecordFieldValue"/> to <see cref="TimeSpanFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.TimeSpan"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static TimeSpanData AsTimeSpanData(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return default;
            }

            recordFieldValue.ValidateType(ResultValueType.TimeSpan);

            return ((TimeSpanFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the string list value by casting the <see cref="RecordFieldValue"/> to <see cref="StringListFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.StringList"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static List<string> AsStringList(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return new List<string>();
            }

            recordFieldValue.ValidateType(ResultValueType.StringList);

            return ((StringListFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the integer list value by casting the <see cref="RecordFieldValue"/> to <see cref="IntegerListFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.IntegerList"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static List<int> AsIntegerList(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return new List<int>();
            }

            recordFieldValue.ValidateType(ResultValueType.IntegerList);

            return ((IntegerListFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the Guid list value by casting the <see cref="RecordFieldValue"/> to <see cref="GuidListFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.GuidList"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static List<Guid> AsGuidList(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return new List<Guid>();
            }

            recordFieldValue.ValidateType(ResultValueType.GuidList);

            return ((GuidListFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the attachment list value by casting the <see cref="RecordFieldValue"/> to <see cref="AttachmentListFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.AttachmentList"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static List<AttachmentFile> AsAttachmentList(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return new List<AttachmentFile>();
            }

            recordFieldValue.ValidateType(ResultValueType.AttachmentList);

            return ((AttachmentListFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the scoring group list value by casting the <see cref="RecordFieldValue"/> to <see cref="ScoringGroupListFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.ScoringGroupList"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static List<ScoringGroup> AsScoringGroupList(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return new List<ScoringGroup>();
            }

            recordFieldValue.ValidateType(ResultValueType.ScoringGroupList);

            return ((ScoringGroupListFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Gets the file list value by casting the <see cref="RecordFieldValue"/> to <see cref="FileListFieldValue"/> and getting its value.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not <see cref="ResultValueType.FileList"/></exception>
        /// <exception cref="InvalidCastException">Thrown if cast is invalid.</exception>
        public static List<int> AsFileList(this RecordFieldValue recordFieldValue)
        {
            if (recordFieldValue == null)
            {
                return new List<int>();
            }

            recordFieldValue.ValidateType(ResultValueType.FileList);

            return ((FileListFieldValue)recordFieldValue).Value;
        }

        /// <summary>
        /// Validates the type is expected.
        /// </summary>
        /// <param name="recordFieldValue"></param>
        /// <param name="expectedType"></param>
        /// <exception cref="InvalidOperationException">Thrown if the <paramref name="recordFieldValue"/> Type is not equal to the <paramref name="expectedType"/>.</exception>
        private static void ValidateType(this RecordFieldValue recordFieldValue, ResultValueType expectedType)
        {
            if (recordFieldValue.Type != expectedType)
            {
                throw new InvalidOperationException($"Unable to get value for field value. Field value type must be {expectedType}. Actual type: {recordFieldValue.Type}");
            }
        }
    }
}