# Onspring .NET SDK

The .NET SDK for the [Onspring](https://www.onspring.com) API simplifies .NET application development for Onspring customers that would like to integrate with their Onspring instance.

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

The most common way to use the SDK is to create an `OnspringClient` instance and call its methods.  Its constructor requires two parameters:

- `baseUrl` - currently this should always be: **`https://api.onspring.com/`**
- `apiKey` - the value obtained by following the steps in the **API Key** section

For example:

```C#
using Onspring.API.SDK;

const string baseUrl = "https://api.onspring.com/";
const string apiKey = "000000ffffff000000ffffff/00000000-ffff-0000-ffff-000000000000";
var onspringClient = new OnspringClient(baseUrl, apiKey);
```

### Bring Your Own HttpClient

We also allow the caller to provide their own `HttpClient` instance, however the `BaseAddress` property must be set in order to use that overload.

```C#
using Onspring.API.SDK;

var myHttpClient = new HttpClient {BaseAddress = new Uri("https://api.onspring.com/")};
const string apiKey = "000000ffffff000000ffffff/00000000-ffff-0000-ffff-000000000000";
var onspringClient = new OnspringClient(apiKey, myHttpClient);
```


## Full API Documentation

When using the SDK, you do not need to be as concerned with the details covered in the full [Onspring API documentation](https://ss-usa.s3.amazonaws.com/c/308463180/media/99045cf01cc2f0ad1795036815/Admin%20Guide%20-%20API%20-%20Onspring.pdf).  However, you may wish to refer to it when determining which values to pass as parameters to some of the `OnspringClient` methods.

Each method on the `OnspringClient` aside from `CanConnectAsync` returns a wrapped response, allowing clients to decide how a response should be handled. This wrapper is the `ApiResponse` class and includes generic types to encompass the response body, if any. In the examples below, we're omitting the validation/error handling around that, however we recommend that each client adds resilience and error handling for potential unsuccessful responses. Please refer to the API documentation/swagger page to determine the possible responses.

## Client lifecycle

The `OnspringClient` is thread-safe and can be used as a singleton or transient.

## Upgrading SDK

Already using a previous version of the SDK? Check out our migration guides below.
- [2.x to 3.0](./docs/migrations/2-to-30.md)

## Example Code

The examples that follow assume you have created an `OnspringClient` as described in the **Start Coding** section.

### Verify connectivity

```C#
bool canConnect = await onspringClient.CanConnectAsync();
```

### Get all apps and surveys

Returns a paged collection of apps/surveys, which can be paged through using the `Onspring.API.SDK.Models.PagingRequest`.

##### Basic
```C#
var apps = await onspringClient.GetAppsAsync();
foreach (App app in apps)
{
    Console.WriteLine($"{app.Id}, {app.Name}");
}
```

##### Paged
Async and synchronous methods allow use of `Onspring.API.SDK.Models.PagingRequest`.

```C#
var pagingRequest = new PagingRequest(1, 10);
var apps = await onspringClient.GetAppsAsync(pagingRequest);
foreach (App app in apps)
{
    Console.WriteLine($"{app.Id}, {app.Name}");
}
```

### Get the fields for an app/survey

Returns a paged collection of fields, which can be paged through using the `Onspring.API.SDK.Models.PagingRequest`.

```C#
const int appId = 5;
var getFieldsResponse = await onspringClient.GetFieldsForAppAsync(appId);
foreach (Field field in getFieldsResponse.Value.Items)
{
    Console.WriteLine($"{field.Id}, {field.AppId}, {field.Name}, {field.Type}, {field.Status}, {field.IsRequired}, {field.IsUnique}");
}
```

### Get one field

```C#
const int fieldId = 40;
var getFieldResponse = await onspringClient.GetFieldAsync(fieldId);
var field = getFieldResponse.Value;
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

Returns a paged collection of reports, which can be paged through using the `Onspring.API.SDK.Models.PagingRequest`.

```C#
const int appId = 1;
var getReportsResponse = await onspringClient.GetReportsForAppAsync(appId);
foreach (var report in getReportsResponse.Value.Items)
{
    Console.WriteLine($"{report.Id}, {report.AppId}, {report.Name}");
}
```

### Get the data from one report

```C#
var reportId = 61;
var dataType = ReportDataType.ChartData;
var dataFormat = DataFormat.Raw;
var getReportResponse = await onspringClient.GetReportAsync(reportId, dataType, dataFormat);
Console.WriteLine(string.Join(", ", getReportResponse.Value.Columns));
foreach (var row in getReportResponse.Value.Rows)
{
    Console.WriteLine(string.Join(", ", row.Cells));
}
```

### Get records

Returns a paged collection of records, which can be paged through using the `Onspring.API.SDK.Models.PagingRequest`.

```C#
var queryRequest = new QueryRecordsRequest
{
    AppId = 5,
    Filter = "not (38 lt 10 or 36 eq 'Smith') and 37 gt datetime'2014-03-01T00:00:00.0000000'",
    FieldIds = new List<int>{ 36, 37, 38 },
    DataFormat = DataFormat.Formatted,
};

var queryResponse = await onspringClient.QueryRecordsAsync(queryRequest);
var records = queryResponse.Value.Items;
foreach (ResultRecord record in records)
{
    Console.WriteLine($"AppId: {record.AppId}, RecordId: {record.RecordId}");
    foreach (RecordFieldValue fieldValue in record.FieldData)
    {
        Console.WriteLine($"FieldId: {fieldValue.FieldId}, Type: {fieldValue.Type}");
    }
}
```

### Get one record

```C#
var getRequest = new GetRecordRequest
{
    AppId = 5,
    RecordId = 100,
    FieldIds = new List<int>{36,37,38},
    DataFormat = DataFormat.Raw,
};
var getResponse = await onspringClient.GetRecordAsync(getRequest);
var record = getResponse.Value;

foreach (var recordFieldValue in record.FieldData)
{
    Console.WriteLine($"FieldId: {recordFieldValue.FieldId}, Type: {recordFieldValue.Type}, Value: {GetResultValueString(recordFieldValue)}");
}

private string GetResultValueString(RecordFieldValue value)
{
    switch (value.Type)
    {
        case ResultValueType.String:
            return value.AsString();
        case ResultValueType.Integer:
            return $"{value.AsNullableInteger()}";
        case ResultValueType.Decimal:
            return $"{value.AsNullableDecimal()}";
        case ResultValueType.Date:
            return $"{value.AsNullableDateTime()}";
        case ResultValueType.TimeSpan:
            var data = value.AsTimeSpanData();
            return $"Quantity: {data.Quantity}, Increment: {data.Increment}, Recurrence: {data.Recurrence}, EndByDate: {data.EndByDate}, EndAfterOccurrences: {data.EndAfterOccurrences}";
        case ResultValueType.Guid:
            return $"{value.AsNullableGuid()}";
        case ResultValueType.StringList:
            return string.Join(", ", value.AsStringList());
        case ResultValueType.IntegerList:
            return string.Join(", ", value.AsIntegerList());
        case ResultValueType.GuidList:
            return string.Join(", ", value.AsGuidList());
        case ResultValueType.AttachmentList:
            var attachmentFiles = value.AsAttachmentList().Select(f => $"FileId: {f.FileId}, FileName: {f.FileName}, Notes: {f.Notes}");
            return string.Join(", ", attachmentFiles);
        case ResultValueType.ScoringGroupList:
            var scoringGroups = value.AsScoringGroupList().Select(g => $"ListValueId: {g.ListValueId}, Name: {g.Name}, Score: {g.Score}, MaximumScore: {g.MaximumScore}");
            return string.Join(", ", scoringGroups);
        default:
            // e.g., future types not supported in this version
            return $"Unsupported ResultValueType: {value.Type}";
    }
}
```

### Add a record

```C#
var record = new ResultRecord
{
    AppId = 5
};

record.FieldData.Add(new IntegerFieldValue(38, 123));
record.FieldData.Add(new DateFieldValue(37, DateTime.UtcNow));
record.FieldData.Add(new StringFieldValue(36, "text value"));

var saveResponse = await onspringClient.SaveRecordAsync(record);
Console.WriteLine($"New Record Id is: {saveResponse.Value.Id}");
foreach (string warning in saveResponse.Value.Warnings)
{
    Console.WriteLine($"Warning: {warning}");
}
```

### Update a record

```C#
var record = new ResultRecord
{
    AppId = 5,
    RecordId = 100
};

record.FieldData.Add(new IntegerFieldValue(38, 378));
record.FieldData.Add(new DateFieldValue(37, DateTime.UtcNow));
record.FieldData.Add(new StringFieldValue(36, "updated text value"));

var saveResponse = await onspringClient.SaveRecordAsync(record);
foreach (string warning in result.Warnings)
{
    Console.WriteLine($"Warning: {warning}");
}
```

### Delete a record

```C#
var appId = 5;
var recordId = 100;
var deleteResponse = await onspringClient.DeleteRecordAsync(appId, recordId);
```

### Add an attachment or image file to a record

Create a stream that contains the file's contents:

```C#
var filePath = "C:/temp/Contract.pdf";
var saveFileRequest = new SaveFileRequest
{
    FieldId = 50,
    RecordId = 100,
    FileStream = File.OpenRead(filePath),
    FileName = Path.GetFileName(filePath),
    ModifiedDate = DateTime.UtcNow,
    Notes = "Initial revision",
};

var saveResponse = await onspringClient.SaveFileAsync(saveFileRequest);
Console.WriteLine($"New File Id is: {saveResponse.Value.Id}");
```

### Get an attachment or image file from a record

```C#
var recordId = 100;
var attachmentFieldId = 50;
var fileId = 1234;
var getFileResponse = await onspringClient.GetFileAsync(recordId, attachmentFieldId, fileId);
using (var result = getFileResponse.Value)
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