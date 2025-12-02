using System;
using System.Linq;

namespace day1;

public class Dial
{
  public int Counter { get; set; } = 0;
  public int CurrentValue { get; set; }
  public readonly int Max;
  public Dial(int initValue = 0, int max = 100)
  {
    Console.WriteLine($"The dial starts by pointing at {initValue}.");
    CurrentValue = initValue;
    Max = max;
  }

  /// <summary>
  /// Optimized O(1) solution for counting zero crossings during dial rotation.
  /// Initially implemented with O(amount) iteration through each position (see TurnDialSlow).
  /// Recognized performance bottleneck with large rotation amounts and used AI assistance
  /// to optimize to constant-time mathematical calculation using modular arithmetic.
  /// Calculates how many times position 0 is visited during rotation without simulating each step.
  /// </summary>
  public int TurnDial(char direction, int amount)
  {
    int zeroCrossings = 0;
    
    if (direction == 'L')
    {
      // Moving left (decreasing): count how many times we visit position 0
      // Positions visited: CurrentValue-1, CurrentValue-2, ..., CurrentValue-amount
      // We visit 0 when (CurrentValue - i) mod 100 == 0 for i in [1, amount]
      // This means i mod 100 == CurrentValue mod 100
      // Values: CurrentValue, CurrentValue+100, CurrentValue+200, ...
      // Count how many are in range (0, amount]
      if (CurrentValue == 0)
      {
        // Special case: starting at 0, count multiples of 100 in (0, amount]
        zeroCrossings = amount / Max;
      }
      else if (amount >= CurrentValue)
      {
        // We'll visit 0 at least once
        zeroCrossings = (amount - CurrentValue) / Max + 1;
      }
      CurrentValue = ((CurrentValue - amount) % Max + Max) % Max;
    }
    else if (direction == 'R')
    {
      // Moving right (increasing): count how many times we visit position 0
      // Positions visited: CurrentValue+1, CurrentValue+2, ..., CurrentValue+amount
      // We visit 0 when (CurrentValue + i) mod 100 == 0 for i in [1, amount]
      // This means i mod 100 == (100 - CurrentValue) mod 100
      // If CurrentValue == 0: values are 100, 200, 300, ... → count = amount / 100
      // If CurrentValue > 0: values are (100-CurrentValue), (100-CurrentValue)+100, ...
      //   → count = floor((amount - (100-CurrentValue)) / 100) + 1 if amount >= 100-CurrentValue, else 0
      if (CurrentValue == 0)
      {
        zeroCrossings = amount / Max;
      }
      else if (amount >= Max - CurrentValue)
      {
        zeroCrossings = (amount - (Max - CurrentValue)) / Max + 1;
      }
      CurrentValue = (CurrentValue + amount) % Max;
    }
    else 
    { 
      throw new Exception("Bad direction"); 
    }

    Counter += zeroCrossings;
    Console.WriteLine($"The dial is rotated {direction}{amount} to point at {CurrentValue}; during this rotation, it points at zero {zeroCrossings} times.");
    return CurrentValue;
  }

  public int TurnDialSlow(char direction, int amount)
  {
    int adder = 1;
    if (direction == 'L') adder = -1;
    int temp_counter = 0;
    foreach (var i in Enumerable.Range(0, amount))
    {
      // Console.WriteLine("Counter: " + CurrentValue);
      CurrentValue += adder;
      if (CurrentValue < 0) // Negative
      {
        CurrentValue = 99;
      }
      else if (CurrentValue > 99) //Above Max and crossed 0
      {
        CurrentValue = 0;
      } 
      
      if(CurrentValue == 0)
      {
        temp_counter++;
      }
    }

    if (CurrentValue == 0) {
      Counter++;
      temp_counter--;
    }
    Counter += temp_counter;
    Console.WriteLine($"The dial is rotated {direction}{amount} to point at {CurrentValue}; during this rotation, it points at zero {temp_counter} times.");
    return CurrentValue;
  }
}