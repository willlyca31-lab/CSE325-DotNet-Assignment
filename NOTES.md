# CSE325 – .NET Applications with C#

**Student:** Wilson Cardichon  
**Course:** CSE325 – Applied Programming  
**Technology:** C#, .NET 8, ASP.NET Core  
**Repository:** [Insert GitHub repository URL]

---

## 1. Evidence – Pizza API

The Pizza API was developed using ASP.NET Core controllers.

The PizzaService seed data includes the following pizzas:

1. Margherita
2. Pepperoni
3. Hawaiian
4. Mexican Pizza (additional pizza added for this assignment)

**Screenshot evidence:**

[Insert screenshot showing the four pizzas returned by GET /api/pizzas or Swagger.]

---

## 2. CRUD Operations – Requests and Responses

### GET – Read

**Request:**

GET /api/pizzas

**Expected response:**

HTTP 200 OK

```json
[
  {"id":1,"name":"Margherita","isGlutenFree":false},
  {"id":2,"name":"Pepperoni","isGlutenFree":false},
  {"id":3,"name":"Hawaiian","isGlutenFree":false},
  {"id":4,"name":"Mexican Pizza","isGlutenFree":false}
]
```

**Evidence:** [Insert GET screenshot.]

### POST – Create

**Request:**

POST /api/pizzas

**Request body:**

```json
{
  "name": "BBQ Chicken Pizza",
  "isGlutenFree": false
}
```

**Response:**

```json
{
  "id": 5,
  "name": "BBQ Chicken Pizza",
  "isGlutenFree": false
}
```

**Status code:** HTTP 201 Created

**Evidence:** [Insert POST screenshot.]

### PUT – Update

**Request:**

PUT /api/pizzas/5

**Request body:**

```json
{
  "name": "BBQ Chicken Pizza Deluxe",
  "isGlutenFree": true
}
```

**Response:** No response body.

**Status code:** HTTP 204 No Content

**Evidence:** [Insert PUT screenshot and GET verification.]

### DELETE – Delete

**Request:**

DELETE /api/pizzas/5

**Response:** No response body.

**Status code:** HTTP 204 No Content

**Evidence:** [Insert DELETE screenshot and GET verification showing HTTP 404.]

---

## 3. Sales Summary Function

**Project:** FileSalesReport

The following function reads sales data from multiple text files, calculates the total sales for each file, calculates the overall sales total, and generates a SalesSummary.txt report.

```csharp
static void GenerateSalesSummary(string directoryPath)
{
    string[] salesFiles = Directory.GetFiles(
        directoryPath,
        "*.txt"
    );

    decimal totalSales = 0;

    var salesDetails = new StringBuilder();

    CultureInfo currencyCulture =
        CultureInfo.GetCultureInfo("en-US");

    foreach (string file in salesFiles)
    {
        string[] lines = File.ReadAllLines(file);

        decimal fileTotal = 0;

        foreach (string line in lines)
        {
            if (decimal.TryParse(
                line,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal amount))
            {
                fileTotal += amount;
            }
        }

        totalSales += fileTotal;

        salesDetails.AppendLine(
            $"  {Path.GetFileName(file)}: {fileTotal.ToString("C", currencyCulture)}"
        );
    }

    StringBuilder report = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");

    report.AppendLine(
        $"Total Sales: {totalSales.ToString("C", currencyCulture)}"
    );

    report.AppendLine();
    report.AppendLine("Details:");

    report.Append(salesDetails);

    string reportPath = Path.Combine(
        Directory.GetCurrentDirectory(),
        "SalesSummary.txt"
    );

    File.WriteAllText(reportPath, report.ToString());

    Console.WriteLine("Sales report generated successfully!");
    Console.WriteLine(report);
}
```

**Generated file:** SalesSummary.txt

**Evidence:** [Insert screenshot showing the generated sales report.]

---

## 4. Learning Reflection

This assignment helped me review C# programming fundamentals and understand how the .NET platform supports application development.

I practiced creating projects, managing NuGet dependencies, debugging applications, and working with files and directories.

I also developed an ASP.NET Core Web API using controllers and services to implement the four basic CRUD operations.

Finally, I extended the file-handling application by creating a sales summary generator that reads multiple files, calculates individual and overall sales totals, and generates a formatted report.

**Repository:** [Insert GitHub URL]