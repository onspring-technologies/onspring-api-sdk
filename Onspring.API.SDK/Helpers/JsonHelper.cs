#region Copyright
// /* 
//  * Onspring API SDK
//  * Copyright (c) 2010, 2016 Onspring Technologies, LLC. All Rights Reserved.
//  * 
//  *  
// */
#endregion
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using Onspring.API.SDK.ResultValues;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Onspring.API.SDK.Helpers
{
    internal static class JsonHelper
    {

        public static ResultRecord LoadRecord(Stream inputStream)
        {
            ResultRecord result = null;
            ProcessToken(inputStream, token => result = LoadRecord(token));
            return result;
        }

        public static IReadOnlyList<ResultRecord> LoadRecords(Stream inputStream)
        {
            var result = new List<ResultRecord>();
            ProcessArray(inputStream, array => result.AddRange(array.Select(LoadRecord)));
            return result;
        }

        private static ResultRecord LoadRecord(JToken recordJson)
        {
            var record = new ResultRecord
            {
                AppId = (int)recordJson["AppId"],
                RecordId = (int)recordJson["RecordId"],
            };
            var fieldArray = (JArray)recordJson["FieldData"];
            LoadFieldValueContainer(record.Values, fieldArray);
            return record;
        }

        private static void LoadFieldValueContainer(FieldValueContainer values, JArray valueArray)
        {
            foreach (var valueJson in valueArray)
            {
                var type = ParseEnum<ResultValueType>(valueJson["Type"]);
                var rawValue = valueJson["Value"];
                var value = GetResultValue(type, rawValue);
                if (value != null)
                {
                    var fieldId = (int)valueJson["FieldId"];
                    values[fieldId] = value;
                }
            }
        }

        private static ResultValue GetResultValue(ResultValueType type, JToken rawValue)
        {
            switch (type)
            {
                case ResultValueType.String:
                    return new StringValue((string)rawValue);
                case ResultValueType.Integer:
                    return new IntegerValue((int?)rawValue);
                case ResultValueType.Decimal:
                    return new DecimalValue((decimal?)rawValue);
                case ResultValueType.Date:
                    return new DateValue((DateTime?)rawValue);
                case ResultValueType.TimeSpan:
                    var data = new TimeSpanData
                    {
                        Quantity = (int)rawValue["Quantity"],
                        Increment = ParseEnum<TimeSpanIncrement>(rawValue["Increment"]),
                        Recurrence = ParseEnum<TimeSpanRecurrenceType>(rawValue["Recurrence"]),
                        EndByDate = (DateTime?)rawValue["EndByDate"],
                        EndAfterOccurrences = (int?)rawValue["EndAfterOccurrences"],
                    };
                    return new TimeSpanValue(data);
                case ResultValueType.Guid:
                    return new GuidValue((Guid?)rawValue);
                case ResultValueType.StringList:
                    var stringTokens = (JArray)rawValue;
                    var stringList = new List<string>(stringTokens.Select(t => (string)t));
                    return new StringListValue(stringList);
                case ResultValueType.IntegerList:
                    var intTokens = (JArray)rawValue;
                    var intList = new List<int>(intTokens.Select(t => (int)t));
                    return new IntegerListValue(intList);
                case ResultValueType.GuidList:
                    var guidTokens = (JArray)rawValue;
                    var guidList = new List<Guid>(guidTokens.Select(t => (Guid)t));
                    return new GuidListValue(guidList);
                case ResultValueType.AttachmentList:
                    var attachmentTokens = (JArray)rawValue;
                    var attachmentList = attachmentTokens.Select(attachmentToken => new AttachmentFile
                    {
                        FileId = (int)attachmentToken["FileId"],
                        FileName = (string)attachmentToken["FileName"],
                        Notes = (string)attachmentToken["Notes"],
                    }).ToArray();
                    return new AttachmentListValue(attachmentList);
                case ResultValueType.ScoringGroupList:
                    var scoringGroupTokens = (JArray)rawValue;
                    var scoringGroupList = scoringGroupTokens.Select(scoringGroupToken => new ScoringGroup
                    {
                        ListValueId = (Guid)scoringGroupToken["ListValueId"],
                        Name = (string)scoringGroupToken["Name"],
                        Score = (decimal)scoringGroupToken["Score"],
                        MaximumScore = (decimal)scoringGroupToken["MaximumScore"],
                    }).ToArray();
                    return new ScoringGroupListValue(scoringGroupList);
            }
            // e.g., future types not supported in this version
            return null;
        }

        public static void ProcessArray(Stream inputStream, Action<JArray> arrayProcessingCallback)
        {
            using (var reader = new StreamReader(inputStream))
            using (JsonReader jsReader = new JsonTextReader(reader))
            {
                var deserialized = (JArray)JToken.ReadFrom(jsReader);
                arrayProcessingCallback(deserialized);
            }
        }

        public static void ProcessToken(Stream inputStream, Action<JToken> tokenProcessingCallback)
        {
            using (var reader = new StreamReader(inputStream))
            using (JsonReader jsReader = new JsonTextReader(reader))
            {
                var deserialized = JToken.ReadFrom(jsReader);
                tokenProcessingCallback(deserialized);
            }
        }

        public static T ParseEnum<T>(JToken value)
        {
            return (T)(object)(int)value;
        }

    }
}
