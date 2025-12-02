// See https://aka.ms/new-console-template for more information
using day1;

var input = """
L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
""";

Dial d = new Dial(50);

foreach(var value in input.Split())
{
  // if (string.IsNullOrEmpty(value)) continue;
  d.TurnDial(value[0], int.Parse(value.Substring(1)));
}

Console.WriteLine("Counter: " + d.Counter);


d = new Dial(50);
// return 0;

foreach(var value in File.ReadAllLines("input.dat"))
{
  // if (string.IsNullOrEmpty(value)) continue;
  d.TurnDial(value[0], int.Parse(value.Substring(1)));
}

Console.WriteLine("Counter: " + d.Counter);