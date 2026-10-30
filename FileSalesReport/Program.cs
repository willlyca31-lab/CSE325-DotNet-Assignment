
// CSE325 - Working with Files and Directories
// Additional assignment requirement:
// Generate a sales summary report containing the
// actual sales total and the detailed total for each file.

using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

string salesDirectory = Path.Combine(
    Directory.GetCurrentDirectory(),
    "Sales"
);

// Create the directory if it does not exist.
Directory.CreateDirectory(salesDirectory);

// Generate the sales report.
GenerateSalesSummary(salesDirectory);

static void GenerateSalesSummary(string directoryPath)
{
    // Find all text files containing sales information.
    string[] salesFiles = Directory.GetFiles(
        directoryPath,
        "*.txt"
    );

    // Store the overall sales amount.
    decimal totalSales = 0;

    // Store each filename and its calculated sales total.
    var salesDetails = new StringBuilder();

    CultureInfo currencyCulture =
        CultureInfo.GetCultureInfo("en-US");

    foreach (string file in salesFiles)
    {
        // Read every line from the current sales file.
        string[] lines = File.ReadAllLines(file);

        decimal fileTotal = 0;

        foreach (string line in lines)
        {
            // Convert each line into a decimal amount.
            if (decimal.TryParse(
                line,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out decimal amount))
            {
                fileTotal += amount;
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine(
                    $"Warning: Invalid sales amount in {Path.GetFileName(file)}: {line}"
                );
            }
        }

        // Add this file's total to the overall total.
        totalSales += fileTotal;

        // Add the file's sales details to the report.
        salesDetails.AppendLine(
            $"  {Path.GetFileName(file)}: {fileTotal.ToString("C", currencyCulture)}"
        );
    }

    // Build the complete report using StringBuilder.
    StringBuilder report = new StringBuilder();

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");

    report.AppendLine(
        $"Total Sales: {totalSales.ToString("C", currencyCulture)}"
    );

    report.AppendLine();
    report.AppendLine("Details:");

    report.Append(salesDetails);

    // Save the report outside the Sales directory.
    string reportPath = Path.Combine(
        Directory.GetCurrentDirectory(),
        "SalesSummary.txt"
    );

    File.WriteAllText(reportPath, report.ToString());

    Console.WriteLine("Sales report generated successfully!");
    Console.WriteLine($"Report location: {reportPath}");
    Console.WriteLine();
    Console.WriteLine(report);
}
