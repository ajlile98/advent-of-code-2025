using System;

namespace day3;

public class Bank
{
  public int[] Batteries { get; set; }
  public Bank(string bank)
  {
    var temp = bank.Select(c => int.Parse($"{c}"));
    Batteries = temp.ToArray();
  }
  public long CalculateLargestBank(int count)
  {
    var maxJoltages = new JoltageDigit[count];
    for(int i = 0; i < maxJoltages.Length; i++)
    {
      maxJoltages[i] = new JoltageDigit();
    }
    for (int digit = 0; digit < maxJoltages.Length; digit++)
    {
      int startIndex = digit == 0 ? 0 : maxJoltages[digit - 1].index + 1;
      for (int i = startIndex; i <= Batteries.Length - (count - digit); i++)
      {
        if (Batteries[i] > maxJoltages[digit].value)
        {
          maxJoltages[digit] = new JoltageDigit(i, Batteries[i]);
        }
      }

    }

    var maxJoltagesValues = maxJoltages.Select(x => x.value);
    return long.Parse(string.Join("", maxJoltagesValues));
  }
}

public record JoltageDigit(int index = -1, int value = 0);