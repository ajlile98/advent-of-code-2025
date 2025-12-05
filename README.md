# Advent of Code 2025 - C# Solutions

My solutions for [Advent of Code 2025](https://adventofcode.com/2025) written in C#.

## About

Advent of Code is an annual set of Christmas-themed programming challenges that can be solved in any programming language. This repository contains my solutions implemented in C# (.NET).

## Structure

Each day's solution is organized in its own directory:

```
advent-of-code-2025/
├── day1/
│   ├── Program.cs
│   ├── Dial.cs
│   ├── day1.csproj
│   └── input.dat
├── day2/
│   └── ...
└── README.md
```

## Running Solutions

To run a specific day's solution:

```bash
cd day1
dotnet run
```

To build and debug:

```bash
dotnet build
```

## Requirements

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)

## Progress

| Day | Part 1 | Part 2 | Notes |
|-----|--------|--------|-------|
| [Day 1](./day1) | ⭐ | ⭐ | Optimized dial rotation with O(1) algorithm |
| [Day 2](./day2) | ⭐ | ⭐ | Product ID range validation |
| [Day 3](./day3) | ⭐ | ⭐ | Bank transaction processing |
| [Day 4](./day4) | ⭐ | ⭐ | Paper roll storage accessibility check |
| ... | | | |

## Highlights

### Day 1: Dial Rotation Optimization
Initially implemented with O(n) iteration, then optimized to O(1) using mathematical calculation of zero crossings. See [Dial.cs](./day1/Dial.cs) for the optimized solution using modular arithmetic.

### Day 4: Paper Roll Accessibility
Implemented a grid-based algorithm to count accessible paper rolls based on adjacent neighbor conditions. A roll is accessible if it has fewer than 4 rolls in the 8 surrounding positions (cardinal + diagonal directions).

---

⭐ **24 Stars Goal** ⭐
