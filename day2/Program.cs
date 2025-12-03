// See https://aka.ms/new-console-template for more information
using day2;

// var lines = File.ReadAllLines("input.dat");
string[] lines = ["11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124"];

var IdRanges = lines[0].Split(",");
var fullInvalid = new List<string>();

foreach (var idRange in IdRanges)
{
  var IdRange = idRange.Split("-");

  var range = new ProductIdRange(IdRange[0], IdRange[1]);
  // string leading = range.GetPrefix();
  // Console.WriteLine($"Leading: {leading}. {range.Min} {range.Max}");
  var invalid = range.FindInvalidIDs();
  fullInvalid.AddRange(invalid);
}

double sum = 0;
var distinctInvalid = fullInvalid
  .Distinct()
  .Order()
  .ToList();;
foreach(var id in distinctInvalid)
{
  Console.WriteLine($"InvalidId: {id}");
  sum += double.Parse(id);
}
Console.WriteLine($"Sum: {sum}");


// Console.WriteLine($"Valid: {ProductIdRange.IsValidId("22")}");
// Console.WriteLine($"Valid: {ProductIdRange.IsValidId("123")}");
// Console.WriteLine($"Valid: {ProductIdRange.IsValidId("123123")}");

