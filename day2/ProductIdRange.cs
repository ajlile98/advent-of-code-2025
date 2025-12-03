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

  public static bool IsValidIdSimple(string id)
  {
    var first = id.Substring(0, id.Length / 2);
    var second = id.Substring(id.Length / 2);
    // Console.WriteLine($"first: {first} second: {second}");
    return !(first == second);
  }
  public static bool IsValidId(string id)
  {
    var length = id.Length;
    for (int patternLength = 1; patternLength < length / 2; patternLength++)
    {
      if (length % patternLength == 0)
      {
        string pattern = id.Substring(0, patternLength);
        bool isRepeated = true;

        for (int i = patternLength; i < length; i += patternLength)
        {
          if (id.Substring(i, patternLength) != pattern)
          {
            isRepeated = false;
            break;
          }
        }
        if (isRepeated)
        {
          return false;
        }
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
      // Console.WriteLine($"Checking valid id: {id}");
      if (!IsValidId(id))
      {
        // Console.WriteLine($"id is not valid: {id}");
        invalidIDs.Add(id);
      }
    }

    // Console.WriteLine($"Invalid Count: {invalidIDs.Count()}");
    return invalidIDs;
  }
}
