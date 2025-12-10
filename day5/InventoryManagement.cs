using System;

namespace day5;

public class InventoryManagement
{
  (long Start, long End)[] FreshIngredientRanges {get; set;}
  long[] AvailableProducts {get;set;}

  public InventoryManagement((long Start, long End)[] ranges, long[] availableProducts)
  {
    FreshIngredientRanges = ranges;
    AvailableProducts = availableProducts;
  }

  public long[] FindFreshIngredients()
  {
    List<long> AvailableIngredients = new();
    foreach(var product in AvailableProducts)
    {
      foreach(var range in FreshIngredientRanges)
      {
        if(product >= range.Start && product <= range.End)
        {
          AvailableIngredients.Add(product);
          break; // Found in a range, no need to check other ranges
        }
      }
    }
    return AvailableIngredients.ToArray();
  }

  public long CountAllFreshIngredients()
  {
    var sortedRanges = FreshIngredientRanges.OrderBy(r => r.Start).ToArray();
    
    long count = 0;
    long currentStart = sortedRanges[0].Start;
    long currentEnd = sortedRanges[0].End;
    
    for (int i = 1; i < sortedRanges.Length; i++)
    {
      var range = sortedRanges[i];
      
      if (range.Start <= currentEnd + 1)
      {
        currentEnd = Math.Max(currentEnd, range.End);
      }
      else
      {
        count += currentEnd - currentStart + 1;
        currentStart = range.Start;
        currentEnd = range.End;
      }
    }
    
    count += currentEnd - currentStart + 1;
    
    return count;
  }
}
