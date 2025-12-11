
using day6;

var input = """
123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  
""";

// var lines = input.Split('\n');
var lines = File.ReadLines("input.dat").ToArray();
var Operators = lines[^1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => s[0]).ToArray();

var calc = new CephalopodCalculator(operators: Operators, lines: lines[0..^1]);
var result = calc.CalculateTotal();
Console.WriteLine($"Total: {result}");

