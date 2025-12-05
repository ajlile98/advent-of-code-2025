using System;
using System.IO.Pipes;
using System.Text;
using Microsoft.VisualBasic;

namespace day4;

public class PaperRollStorage
{   

    public int[][] PaperRolls {get;set;}
    public PaperRollStorage(string grid)
    {
        var grid_lines = grid.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        PaperRolls = new int[grid_lines.Length][];
        for(var i = 0; i < grid_lines.Length; i++)
        {
            var line = grid_lines[i].TrimEnd();
            PaperRolls[i] = new int[line.Length];
            for(var j = 0; j < line.Length; j++)
            {
                var roll = line[j];
                PaperRolls[i][j] = roll == '@' ? 1 : 0;
            }
        }
    }

    public int RemoveAccessibleRolls(int minimumCount = 4)
    {
        var count = 0;
        for(var i = 0; i < PaperRolls.Length; i++)
        {
            var row = PaperRolls[i];
            for(var j = 0; j < row.Length; j++)
            {
                if(PaperRolls[i][j] == 1 && IsRollAccessible(i, j, minimumCount))
                {
                    PaperRolls[i][j] = 0;
                    count++;
                }
            }
        }
        return count;
    }

    public int CountAccessibleRolls(int minimumCount = 4)
    {
        var count = 0;
        for(var i = 0; i < PaperRolls.Length; i++)
        {
            var row = PaperRolls[i];
            for(var j = 0; j < row.Length; j++)
            {
                if(PaperRolls[i][j] == 1 && IsRollAccessible(i, j, minimumCount))
                {
                    count++;
                }
            }
        }
        return count;
    }

    public bool IsRollAccessible(int row, int col, int minimumCount)
    {
        int rollCount = 0;

        if (IsPositionRoll(row, col - 1)) rollCount++;  
        if (IsPositionRoll(row, col + 1)) rollCount++;  
        if (IsPositionRoll(row - 1, col)) rollCount++;  
        if (IsPositionRoll(row + 1, col)) rollCount++;  
        if (IsPositionRoll(row - 1, col + 1)) rollCount++; 
        if (IsPositionRoll(row - 1, col - 1)) rollCount++; 
        if (IsPositionRoll(row + 1, col + 1)) rollCount++; 
        if (IsPositionRoll(row + 1, col - 1)) rollCount++; 

        return rollCount < minimumCount;
    }

    private bool IsPositionRoll(int row, int col)
    {
        if(row < 0 || row >= PaperRolls.Length) return false;
        if(col < 0 || col >= PaperRolls[row].Length) return false;
        return PaperRolls[row][col] == 1;
    }

    public override string ToString()
    {   
        var b = new StringBuilder();
        foreach(var line in PaperRolls)
        {
            foreach(var roll in line)
            {
                b.Append(roll);
            }
            b.Append("\n");
        }
        return b.ToString();
    }
}