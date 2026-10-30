
// CSE325 - C# Programming Fundamentals
// This program demonstrates basic C# syntax,
// variables, data types, conditions, loops, arrays,
// and methods.

using System;

Console.WriteLine("================================");
Console.WriteLine("       C# PROGRAMMING REVIEW");
Console.WriteLine("================================");

// 1. Variables and data types
string studentName = "Wilson Cardichon";
int age = 30;
double grade = 95.5;
bool isEnrolled = true;

Console.WriteLine("\n1. VARIABLES AND DATA TYPES");

Console.WriteLine($"Student: {studentName}");
Console.WriteLine($"Age: {age}");
Console.WriteLine($"Grade: {grade}");
Console.WriteLine($"Enrolled: {isEnrolled}");

// 2. Conditional statements
Console.WriteLine("\n2. CONDITIONAL STATEMENTS");

if (grade >= 90)
{
    Console.WriteLine("Excellent performance!");
}
else
{
    Console.WriteLine("Keep practicing!");
}

// 3. For loop
Console.WriteLine("\n3. FOR LOOP");

for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Number: {i}");
}

// 4. Arrays and foreach
Console.WriteLine("\n4. ARRAYS AND FOREACH");

string[] subjects =
{
    "C#",
    ".NET",
    "ASP.NET Core",
    "Web API"
};

foreach (string subject in subjects)
{
    Console.WriteLine($"Subject: {subject}");
}

// 5. Methods and calculations
Console.WriteLine("\n5. METHODS");

int result = AddNumbers(10, 20);

Console.WriteLine($"10 + 20 = {result}");

// This method receives two integers and returns their sum.
static int AddNumbers(int first, int second)
{
    return first + second;
}

Console.WriteLine("\nC# programming review completed!");
