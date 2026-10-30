
// CSE325 - Debugging Practice
// This application demonstrates variables,
// calculations, and debugging with breakpoints.

using System;

int firstNumber = 100;
int secondNumber = 25;

// Place a breakpoint on the next line.
int total = CalculateTotal(firstNumber, secondNumber);

Console.WriteLine($"First number: {firstNumber}");
Console.WriteLine($"Second number: {secondNumber}");
Console.WriteLine($"Total: {total}");

static int CalculateTotal(int first, int second)
{
    // Inspect the values of first and second here.
    int result = first + second;

    return result;
}
