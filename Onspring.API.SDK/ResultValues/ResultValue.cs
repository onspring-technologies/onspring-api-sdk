#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using System;
using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public abstract class ResultValue
    {
        public abstract ResultValueType Type { get; }

        /// <summary>
        /// Casts the ResultValue to a StringValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public string AsString => ((StringValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to an IntegerValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public int? AsNullableInteger => ((IntegerValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a DecimalValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public decimal? AsNullableDecimal => ((DecimalValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a DateValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public DateTime? AsNullableDateTime => ((DateValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a TimeSpanValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public TimeSpanData AsTimeSpanData => ((TimeSpanValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a GuidValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public Guid? AsNullableGuid => ((GuidValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a StringListValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public IReadOnlyList<string> AsStringList => ((StringListValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to an IntegerListValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public IReadOnlyList<int> AsIntegerList => ((IntegerListValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a GuidListValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public IReadOnlyList<Guid> AsGuidList => ((GuidListValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to an AttachmentListValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public IReadOnlyList<AttachmentFile> AsAttachmentList => ((AttachmentListValue)this).Value;

        /// <summary>
        /// Casts the ResultValue to a ScoringGroupListValue (throws an InvalidCastException if the cast is not valid)
        /// </summary>
        public IReadOnlyList<ScoringGroup> AsScoringGroupList => ((ScoringGroupListValue)this).Value;
    }

}