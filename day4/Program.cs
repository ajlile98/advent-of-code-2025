// See https://aka.ms/new-console-template for more information
using day4;
using Microsoft.VisualBasic;

var input = """
..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.
""";

var paperRollColumns = new PaperRollStorage(File.ReadAllText("input.dat"));
// var paperRollColumns = new PaperRollStorage(input);
Console.WriteLine($"Accessible Roll Count: {paperRollColumns.CountAccessibleRolls(4)}");
// Console.WriteLine(paperRollColumns);
int count = 0;
int fullCount = 0;
while((count = paperRollColumns.RemoveAccessibleRolls()) != 0)
{
    Console.WriteLine($"Removed Roll Count: {count}");
    fullCount += count;
}
Console.WriteLine($"Removed Roll FullCount: {fullCount}");