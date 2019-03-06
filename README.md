# Onspring .NET SDK

The .NET SDK for the [Onspring](https://www.onspring.com) API simplifies .NET application development for Onspring customers that would like to integrate with their Onspring instance.

## Prerequisites

- .NET 4.6.1 or later

## Installation

Install the SDK using Nuget

`PM> Install-Package Onspring.API.SDK`

## API Key

In order to successfully interact with the Onspring API, you must use an API key.  API keys may be obtained by an Onspring user with permissions to read API Keys for your instance, using the following instructions: 

1.	Within Onspring, navigate to Administration | Security | API Keys.  
2.	On the list page, add a new API Key (requires Create permissions) or click an existing API Key to view its details.  
3.	On the details page for an API Key, expand the **Developer Information** section.  Copy the **X-ApiKey Header** value from this section.

#### Important

- An API Key must have a **Status** of *Enabled* (available on the details page) in order to be used.
- Each API Key has an associated **Role** that controls the permissions for requests made using that API Key.  An Onspring administrator may configure those permissions as they would any other Role in Onspring.  If the API Key does not have sufficient permissions to perform the requested action, an error will be returned.

## Sample Projects

- [Onspring.ApiDemo](https://github.com/onspring-technologies/Onspring.ApiDemo) - a WinForms application that can be used to try out the SDK features in a more visual way
- [Onspring.ADSync](https://github.com/onspring-technologies/Onspring.ADSync) - a console application that helps you learn the recommended approach for creating an integration to an Onspring instance using the SDK

## Start Coding

The most common way to use the SDK is to create an `HttpHelper` instance and call its methods.  Its constructor requires two parameters:

- `baseUrl` - currently this should always be: **`https://api.onspring.com/v1`**
- `apiKey` - the value obtained by following the steps in the **API Key** section

For example:

```C#
using Onspring.API.SDK.Helpers;

const string baseUrl = "https://api.onspring.com/v1";
const string apiKey = "000000ffffff000000ffffff/00000000-ffff-0000-ffff-000000000000";
var httpHelper = new HttpHelper(baseUrl, apiKey);
```

## Full API Documentation

When using the SDK, you do not need to be as concerned with the details covered in the full [Onspring API documentation](https://goo.gl/vgyHm2).  However, you may wish to refer to it when determining which values to pass as parameters to some of the `HttpHelper` methods.

## Example Code

The examples that follow assume you have created an `HttpHelper` as described in the **Start Coding** section.

## Async Methods

The latest version of the SDK includes async versions of all HttpHelper methods - examples of the new calls have been provided. The existing synchronous methods have been marked obsolete and will be removed from future versions of the SDK.

### Verify connectivity

##### Synchronous
```C#
if (httpHelper.CanConnect())
{
  // we're connected
}
```

##### Asynchronous
```C#
var canConnect = await httpHelper.CanConnectAsync();
if (canConnect)
{
  // we're connected                
}
```

### Get the list of apps and surveys

##### Synchronous
```C#
foreach (App app in httpHelper.GetApps())
{
	Console.WriteLine($"{app.Id}, {app.Name}");
}
```

##### Asynchronous
```C#
var apps = await httpHelper.GetAppsAsync();
foreach (App app in apps)
{
    Console.WriteLine($"{app.Id}, {app.Name}");
}
```

### Get the fields for an app/survey

##### Synchronous
```C#
var appId = 5;
foreach (Field field in httpHelper.GetAppFields(appId))
{
	Console.WriteLine($"{field.Id}, {field.AppId}, {field.Name}, {field.Type}, {field.Status}, {field.IsRequired}, {field.IsUnique}");
}
```

##### Asynchronous
```C#
var appId = 5;
var fields = await httpHelper.GetAppFieldsAsync(appId);
foreach (Field field in fields)
{
    Console.WriteLine($"{field.Id}, {field.AppId}, {field.Name}, {field.Type}, {field.Status}, {field.IsRequired}, {field.IsUnique}");
}
```

### Get one field

##### Synchronous
```C#
var fieldId = 40;
Field field = httpHelper.GetAppField(fieldId);
Console.WriteLine($"{field.Id}, {field.AppId}, {field.Name}, {field.Type}, {field.Status}, {field.IsRequired}, {field.IsUnique}");
var referenceField = field as ReferenceField;
if (referenceField != null)
{
    Console.WriteLine($"Multiplicity: {referenceField.Multiplicity}");
}
var listField = field as ListField;
if (listField != null)
{
    Console.WriteLine($"Multiplicity: {listField.Multiplicity}");
    WriteListValues(listField.Values);
}
var formulaField = field as FormulaField;
if (formulaField != null)
{
    Console.WriteLine($"OutputType: {formulaField.OutputType}");
    if (formulaField.OutputType == FormulaOutputType.List)
    {
        WriteListValues(formulaField.Values);
    }
}

private void WriteListValues(IReadOnlyList<ListValue> listValues)
{
    foreach (ListValue value in listValues)
    {
        Console.WriteLine($"{value.Id}, {value.Name}, {value.SortOrder}, {value.NumericValue}, {value.Color}");
    }
}
```

##### Asynchronous
```C#
var fieldId = 40;
Field field = await httpHelper.GetAppFieldAsync(fieldId);
Console.WriteLine($"{field.Id}, {field.AppId}, {field.Name}, {field.Type}, {field.Status}, {field.IsRequired}, {field.IsUnique}");
var referenceField = field as ReferenceField;
if (referenceField != null)
{
    Console.WriteLine($"Multiplicity: {referenceField.Multiplicity}");
}
var listField = field as ListField;
if (listField != null)
{
    Console.WriteLine($"Multiplicity: {listField.Multiplicity}");
    WriteListValues(listField.Values);
}
var formulaField = field as FormulaField;
if (formulaField != null)
{
    Console.WriteLine($"OutputType: {formulaField.OutputType}");
    if (formulaField.OutputType == FormulaOutputType.List)
    {
        WriteListValues(formulaField.Values);
    }
}

private void WriteListValues(IReadOnlyList<ListValue> listValues)
{
    foreach (ListValue value in listValues)
    {
        Console.WriteLine($"{value.Id}, {value.Name}, {value.SortOrder}, {value.NumericValue}, {value.Color}");
    }
}
```

### Get the reports for an app/survey

##### Synchronous
```C#
var appId = 5;
foreach (Report report in httpHelper.GetAppReports(appId))
{
	Console.WriteLine($"{report.Id}, {report.AppId}, {report.Name}");
}
```

##### Asynchronous
```C#
var appId = 5;
var reports = await httpHelper.GetAppReportsAsync(appId);
foreach (Report report in reports)
{
    Console.WriteLine($"{report.Id}, {report.AppId}, {report.Name}");
}
```

### Get the data from one report

##### Synchronous
```C#
var reportId = 61;
var dataType = ReportDataType.ChartData;
var dataFormat = DataFormat.Raw;
ReportData reportData = httpHelper.GetReportData(reportId, dataType, dataFormat);
Console.WriteLine(string.Join(", ", reportData.Columns));
foreach (ReportDataRow row in reportData.Rows)
{
    Console.WriteLine(string.Join(", ", row.Cells));
}
```

##### Asynchronous
```C#
var reportId = 61;
var dataType = ReportDataType.ChartData;
var dataFormat = DataFormat.Raw;
ReportData reportData = await httpHelper.GetReportDataAsync(reportId, dataType, dataFormat);
Console.WriteLine(string.Join(", ", reportData.Columns));
foreach (ReportDataRow row in reportData.Rows)
{
    Console.WriteLine(string.Join(", ", row.Cells));
}
```

### Get records

##### Synchronous
```C#
var appId = 5;
var filter = "not (38 lt 10 or 36 eq 'Smith') and 37 gt datetime'2014-03-01T00:00:00.0000000'";
var recordIds = new[] {100, 101, 102};
var fieldIds = new[] {36, 37, 38};
var dataFormat = DataFormat.Formatted;
var records = httpHelper.GetAppRecords(appId, filter, recordIds, fieldIds, dataFormat);
foreach (ResultRecord record in records)
{
    Console.WriteLine($"AppId: {record.AppId}, RecordId: {record.RecordId}");
    foreach (FieldValueWrapper wrapper in record.Values.WithFieldId())
    {
        Console.WriteLine($"FieldId: {wrapper.FieldId}, Type: {wrapper.Value.Type}");
    }
}
```

##### Asynchronous
```C#
var appId = 5;
var filter = "not (38 lt 10 or 36 eq 'Smith') and 37 gt datetime'2014-03-01T00:00:00.0000000'";
var recordIds = new[] { 100, 101, 102 };
var fieldIds = new[] { 36, 37, 38 };
var dataFormat = DataFormat.Formatted;
var records = await httpHelper.GetAppRecordsAsync(appId, filter, recordIds, fieldIds, dataFormat);
foreach (ResultRecord record in records)
{
    Console.WriteLine($"AppId: {record.AppId}, RecordId: {record.RecordId}");
    foreach (FieldValueWrapper wrapper in record.Values.WithFieldId())
    {
        Console.WriteLine($"FieldId: {wrapper.FieldId}, Type: {wrapper.Value.Type}");
    }
}
```

### Get one record

##### Synchronous
```C#
var appId = 5;
var recordId = 100;
var fieldIds = new[] {36, 37, 38};
var dataFormat = DataFormat.Raw;
ResultRecord record = httpHelper.GetAppRecord(appId, recordId, fieldIds, dataFormat);
foreach (FieldValueWrapper wrapper in record.Values.WithFieldId())
{
    Console.WriteLine($"FieldId: {wrapper.FieldId}, Type: {wrapper.Value.Type}, Value: {GetResultValueString(wrapper.Value)}");
}

private string GetResultValueString(ResultValue value)
{
    switch (value.Type)
    {
        case ResultValueType.String:
            return value.AsString;
        case ResultValueType.Integer:
            return $"{value.AsNullableInteger}";
        case ResultValueType.Decimal:
            return $"{value.AsNullableDecimal}";
        case ResultValueType.Date:
            return $"{value.AsNullableDateTime}";
        case ResultValueType.TimeSpan:
            var data = value.AsTimeSpanData;
            return $"Quantity: {data.Quantity}, Increment: {data.Increment}, Recurrence: {data.Recurrence}, EndByDate: {data.EndByDate}, EndAfterOccurrences: {data.EndAfterOccurrences}";
        case ResultValueType.Guid:
            return $"{value.AsNullableGuid}";
        case ResultValueType.StringList:
            return string.Join(", ", value.AsStringList);
        case ResultValueType.IntegerList:
            return string.Join(", ", value.AsIntegerList);
        case ResultValueType.GuidList:
            return string.Join(", ", value.AsGuidList);
        case ResultValueType.AttachmentList:
            var attachmentFiles = value.AsAttachmentList.Select(f => $"FileId: {f.FileId}, FileName: {f.FileName}, Notes: {f.Notes}");
            return string.Join(", ", attachmentFiles);
        case ResultValueType.ScoringGroupList:
            var scoringGroups = value.AsScoringGroupList.Select(g => $"ListValueId: {g.ListValueId}, Name: {g.Name}, Score: {g.Score}, MaximumScore: {g.MaximumScore}");
            return string.Join(", ", scoringGroups);
        default:
            // e.g., future types not supported in this version
            return $"Unsupported ResultValueType: {value.Type}";
    }
}
```

##### Asynchronous
```C#
var appId = 5;
var recordId = 100;
var fieldIds = new[] { 36, 37, 38 };
var dataFormat = DataFormat.Raw;
ResultRecord record = await httpHelper.GetAppRecordAsync(appId, recordId, fieldIds, dataFormat);
foreach (FieldValueWrapper wrapper in record.Values.WithFieldId())
{
    Console.WriteLine($"FieldId: {wrapper.FieldId}, Type: {wrapper.Value.Type}, Value: {GetResultValueString(wrapper.Value)}");
}

private string GetResultValueString(ResultValue value)
{
    switch (value.Type)
    {
        case ResultValueType.String:
            return value.AsString;
        case ResultValueType.Integer:
            return $"{value.AsNullableInteger}";
        case ResultValueType.Decimal:
            return $"{value.AsNullableDecimal}";
        case ResultValueType.Date:
            return $"{value.AsNullableDateTime}";
        case ResultValueType.TimeSpan:
            var data = value.AsTimeSpanData;
            return $"Quantity: {data.Quantity}, Increment: {data.Increment}, Recurrence: {data.Recurrence}, EndByDate: {data.EndByDate}, EndAfterOccurrences: {data.EndAfterOccurrences}";
        case ResultValueType.Guid:
            return $"{value.AsNullableGuid}";
        case ResultValueType.StringList:
            return string.Join(", ", value.AsStringList);
        case ResultValueType.IntegerList:
            return string.Join(", ", value.AsIntegerList);
        case ResultValueType.GuidList:
            return string.Join(", ", value.AsGuidList);
        case ResultValueType.AttachmentList:
            var attachmentFiles = value.AsAttachmentList.Select(f => $"FileId: {f.FileId}, FileName: {f.FileName}, Notes: {f.Notes}");
            return string.Join(", ", attachmentFiles);
        case ResultValueType.ScoringGroupList:
            var scoringGroups = value.AsScoringGroupList.Select(g => $"ListValueId: {g.ListValueId}, Name: {g.Name}, Score: {g.Score}, MaximumScore: {g.MaximumScore}");
            return string.Join(", ", scoringGroups);
        default:
            // e.g., future types not supported in this version
            return $"Unsupported ResultValueType: {value.Type}";
    }
}
```

### Add a record

##### Synchronous
```C#
var appId = 5;
var numberFieldId = 38;
var dateFieldId = 37;
var textFieldId = 36;
FieldAddEditContainer fieldValues = new FieldAddEditContainer();
fieldValues.Add(numberFieldId, 123.45);
fieldValues.Add(dateFieldId, DateTime.UtcNow);
fieldValues.Add(textFieldId, "text value");
AddEditResult result = httpHelper.CreateAppRecord(appId, fieldValues);
Console.WriteLine($"New Record Id is: {result.CreatedId}");
foreach (string warning in result.Warnings)
{
	Console.WriteLine($"Warning: {warning}");
}
```

##### Asynchronous
```C#
var appId = 5;
var numberFieldId = 38;
var dateFieldId = 37;
var textFieldId = 36;
FieldAddEditContainer fieldValues = new FieldAddEditContainer();
fieldValues.Add(numberFieldId, 123.45);
fieldValues.Add(dateFieldId, DateTime.UtcNow);
fieldValues.Add(textFieldId, "text value");
AddEditResult result = await httpHelper.CreateAppRecordAsync(appId, fieldValues);
Console.WriteLine($"New Record Id is: {result.CreatedId}");
foreach (string warning in result.Warnings)
{
    Console.WriteLine($"Warning: {warning}");
}
```

### Update a record

##### Synchronous
```C#
var appId = 5;
var recordId = 100;
var numberFieldId = 38;
var dateFieldId = 37;
var textFieldId = 36;
FieldAddEditContainer fieldValues = new FieldAddEditContainer();
fieldValues.Add(numberFieldId, 678.90);
fieldValues.Add(dateFieldId, DateTime.UtcNow);
fieldValues.Add(textFieldId, "updated text value");
AddEditResult result = httpHelper.UpdateAppRecord(appId, recordId, fieldValues);
foreach (string warning in result.Warnings)
{
	Console.WriteLine($"Warning: {warning}");
}
```

##### Asynchronous
```C#
var appId = 5;
var recordId = 100;
var numberFieldId = 38;
var dateFieldId = 37;
var textFieldId = 36;
FieldAddEditContainer fieldValues = new FieldAddEditContainer();
fieldValues.Add(numberFieldId, 678.90);
fieldValues.Add(dateFieldId, DateTime.UtcNow);
fieldValues.Add(textFieldId, "updated text value");
AddEditResult result = await httpHelper.UpdateAppRecordAsync(appId, recordId, fieldValues);
foreach (string warning in result.Warnings)
{
    Console.WriteLine($"Warning: {warning}");
}
```

### Delete a record

##### Synchronous
```C#
var appId = 5;
var recordId = 100;
DeleteResult result = httpHelper.DeleteAppRecord(appId, recordId);
```

##### Asynchronous
```C#
var appId = 5;
var recordId = 100;
DeleteResult result = await httpHelper.DeleteAppRecordAsync(appId, recordId);
```

### Add an attachment or image file to a record

If the file you want to add physically exists on disk, you can use the overload that accepts a filePath parameter:

##### Synchronous
```C#
var appId = 5;
var recordId = 100;
var attachmentFieldId = 50;
var filePath = "C:\Users\Public\Documents\Contract.pdf";
var contentType = "application/pdf";
var fileNotes = "Initial revision";
AddEditResult result = httpHelper.AddFileToRecord(appId, recordId, attachmentFieldId, filePath, contentType, fileNotes);
Console.WriteLine($"New File Id is: {result.CreatedId}");
```

##### Asynchronous
```C#
var appId = 5;
var recordId = 100;
var attachmentFieldId = 50;
var filePath = "C:\Users\Public\Documents\Contract.pdf";
var contentType = "application/pdf";
var fileNotes = "Initial revision";
AddEditResult result = await httpHelper.AddFileToRecordAsync(appId, recordId, attachmentFieldId, filePath, contentType, fileNotes);
Console.WriteLine($"New File Id is: {result.CreatedId}");
```

Otherwise, you can create a stream that contains the file's contents and use the other overload:

##### Synchronous
```C#
var appId = 5;
var recordId = 100;
var attachmentFieldId = 50;
var fileName = "Contract.pdf";
var contentType = "application/pdf";
var modifiedTime = DateTime.UtcNow;
var fileNotes = "Initial revision";
using (Stream stream = new MemoryStream())
{
    AddEditResult result = httpHelper.AddFileToRecord(appId, recordId, attachmentFieldId, stream, fileName, contentType, modifiedTime, fileNotes);
    Console.WriteLine($"New File Id is: {result.CreatedId}");
}
```

##### Asynchronous
```C#
var appId = 5;
var recordId = 100;
var attachmentFieldId = 50;
var fileName = "Contract.pdf";
var contentType = "application/pdf";
var modifiedTime = DateTime.UtcNow;
var fileNotes = "Initial revision";
using (Stream stream = new MemoryStream())
{
    AddEditResult result = await httpHelper.AddFileToRecordAsync(appId, recordId, attachmentFieldId, stream, fileName, contentType, modifiedTime, fileNotes);
    Console.WriteLine($"New File Id is: {result.CreatedId}");
}
```

### Get an attachment or image file from a record

##### Synchronous
```C#
var appId = 5;
var recordId = 100;
var attachmentFieldId = 50;
var fileId = 1234;
using (FileResult result = httpHelper.GetFileFromRecord(appId, recordId, attachmentFieldId, fileId))
{
    Console.WriteLine($"FileName is: {result.FileName}");
    Console.WriteLine($"ContentType: {result.ContentType}");
    Console.WriteLine($"ContentLength: {result.ContentLength}");
    using (var fileStream = new FileStream($"C:\Users\Public\Documents\{result.FileName}", FileMode.Create))
    {
       result.Stream.CopyTo(fileStream);
    }
} 
```

##### Asynchronous
```C#           
var appId = 5;
var recordId = 100;
var attachmentFieldId = 50;
var fileId = 1234;
using (FileResult result = await httpHelper.GetFileFromRecordAsync(appId, recordId, attachmentFieldId, fileId))
{
    Console.WriteLine($"FileName is: {result.FileName}");
    Console.WriteLine($"ContentType: {result.ContentType}");
    Console.WriteLine($"ContentLength: {result.ContentLength}");
    using (var fileStream = new FileStream($"C:\Users\Public\Documents\{result.FileName}", FileMode.Create))
    {
        result.Stream.CopyTo(fileStream);
    }
}
```