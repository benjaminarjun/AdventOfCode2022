using AdventOfCode2022.Helpers;
using AdventOfCode2022.Solvers;

string day1Data = DataLoader.GetDataForDay(1);

var counter = new CalorieCounter(day1Data);

Console.WriteLine($"Day 1 Part 1:  {counter.GetMax()}");
Console.WriteLine($"Day 1 Part 2:  {counter.GetTop(3).Sum()}");
