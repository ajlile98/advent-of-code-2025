using System;
using System.Text;

namespace day2;

public class ProductIdRange
{
  public string Min { get; set; }
  public string Max { get; set; }

  public ProductIdRange(string min, string max)
  {
    Min = min;
    Max = max;
  }

  public string GetPrefix()
  {
    StringBuilder builder = new();
    for (int i = 0; i < Min.Length; i++)
    {
      if (Min[i] == Max[i])
        builder.Append(Min[i]);
      else
        return builder.ToString();
    }
    return builder.ToString();
  }

  private static bool IsRepeatedPattern(string id, int patternLength)
  {
    string pattern = id.Substring(0, patternLength);
    
    for (int i = patternLength; i < id.Length; i += patternLength)
    {
      string chunk = id.Substring(i, patternLength);
      if (chunk != pattern)
      {
        return false;
      }
    }
    
    return true;
  }

  private static IEnumerable<int> GetPossiblePatternLengths(string id)
  {
    int length = id.Length;
    
    for (int patternLength = 1; patternLength <= length / 2; patternLength++)
    {
      if (length % patternLength == 0)
      {
        yield return patternLength;
      }
    }
  }

  public static bool IsValidId(string id)
  {
    foreach (int patternLength in GetPossiblePatternLengths(id))
    {
      if (IsRepeatedPattern(id, patternLength))
      {
        return false;
      }
    }
    
    return true;
  }

  public List<string> FindInvalidIDs()
  {
    Console.WriteLine($"Min: {Min} Max: {Max}");
    var invalidIDs = new List<string>();

    var prefix = GetPrefix();
    Console.WriteLine($"Prefix: {prefix} trim {Min.Substring(prefix.Length)}");

    var trimmedMin = Min.Substring(prefix.Length);
    var trimmedMax = Max.Substring(prefix.Length);
    if (string.IsNullOrEmpty(trimmedMin))
      trimmedMin = "0";
    var tempMin = int.Parse(trimmedMin);
    var tempMax = int.Parse(trimmedMax);
    foreach (var i in Enumerable.Range(tempMin, tempMax - tempMin + 1))
    {
      var id = $"{prefix}{i}";
      if (!IsValidId(id))
      {
        invalidIDs.Add(id);
      }
    }

    return invalidIDs;
  }
}
