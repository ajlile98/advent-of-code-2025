// See https://aka.ms/new-console-template for more information

using day5;

var input = """
3-5
10-14
16-20
12-18

1
5
8
11
17
32
""";

input = File.ReadAllText("input.dat");

string[] inputSplit = input.Split("\n\n");
string[] Ranges = inputSplit[0].Split();
string[] AvailableIngredients = inputSplit[1].Split();

var FreshIngredientRanges = new (long Start, long End)[Ranges.Length];
for (int i = 0; i < Ranges.Length; i++)
{
  string[] rangeSplit = Ranges[i].Split('-');
  long rangeMin = long.Parse(rangeSplit[0]);
  long rangeMax = long.Parse(rangeSplit[1]);

  FreshIngredientRanges[i] = (rangeMin, rangeMax);
}

var AvailableIngredientIds = AvailableIngredients.Select( x => long.Parse(x)).ToArray();

var inventory = new InventoryManagement(FreshIngredientRanges, AvailableIngredientIds);

var FreshIngredients = inventory.FindFreshIngredients();
foreach(var item in FreshIngredients)
{
  Console.WriteLine(item);
}
Console.WriteLine(FreshIngredients.Length);

Console.WriteLine("Total fresh ingredient IDs: " + inventory.CountAllFreshIngredients());