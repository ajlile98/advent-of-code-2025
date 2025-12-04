// See https://aka.ms/new-console-template for more information
using day3;

var input = """
987654321111111
811111111111119
234234234234278
818181911112111
""".Split();

long totalJoltage = 0;
foreach (var line in File.ReadLines("input.dat"))
// foreach (var line in input)
{
  var b = new Bank(line);
  Console.WriteLine(string.Join("",b.Batteries));
  long joltage = b.CalculateLargestBank(12);
  Console.WriteLine($"MaxJoltage: {joltage}");
  totalJoltage+=joltage;
}
Console.WriteLine($"Total Joltage: {totalJoltage}");