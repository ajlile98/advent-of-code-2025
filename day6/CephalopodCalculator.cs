using System;
using System.Linq.Expressions;
using Microsoft.VisualBasic;

namespace day6;

public class CephalopodCalculator(char[] operators, string[] lines)
{
  char[] Operators = operators;
  long[] RunningTotals = new long[lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length];
  string[] InputLines = lines;
  public long CalculateTotal()
  {
    for (int i = 0; i < InputLines.Length; i++)
    {
      var operands = InputLines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
      Console.WriteLine($"operands: {string.Join(',', operands)}");
      for(int j = 0; j < operands.Length; j++)
      {
        var operand_str = operands[j];
        if (string.IsNullOrWhiteSpace(operand_str)) continue;
        long operand = long.Parse(operand_str);
        if (RunningTotals[j] == 0)
          RunningTotals[j] = operand;
        else
        {
          RunningTotals[j] = Operate(Operators[j], RunningTotals[j], operand);
        }
          Console.WriteLine($"RunningTotals: {string.Join(',', RunningTotals)}");
      }
    }
    Console.WriteLine($"Final RunningTotals: {string.Join(',', RunningTotals)}");
    return RunningTotals.Sum();
  }

  private long Operate(char op, long x, long y)
  {
    switch (op)
    {
      case '+':
        return x + y;
      case '*':
        return x * y;
      default:
        throw new Exception($"Operator {op} not supported");
    }

  }
}
