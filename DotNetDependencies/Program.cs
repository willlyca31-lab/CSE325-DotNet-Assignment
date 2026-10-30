
// CSE325 - Working with Dependencies
// Demonstrates using an external NuGet package
// to serialize and deserialize JSON data.

using Newtonsoft.Json;

var student = new
{
    Name = "Wilson",
    Course = "CSE325",
    Language = "C#"
};

// Convert the object into JSON.
string json = JsonConvert.SerializeObject(
    student,
    Formatting.Indented
);

Console.WriteLine("JSON output:");
Console.WriteLine(json);

// Convert JSON back into an object.
var restoredStudent = JsonConvert.DeserializeObject<dynamic>(json);

Console.WriteLine("\nDependency successfully used.");
Console.WriteLine(restoredStudent);
