using AdventOfCode2022.Helpers;
using AdventOfCode2022.Solvers.Day01;
using AdventOfCode2022.Solvers.Day02;
using AdventOfCode2022.Solvers.Day03;


// Day 1
string day1Data = DataLoader.GetDataForDay(1);

var counter = new CalorieCounter(day1Data);

Console.WriteLine($"Day 1 Part 1:  {counter.GetMax()}");
Console.WriteLine($"Day 1 Part 2:  {counter.GetTop(3).Sum()}");

// Day 2
string day2Data = DataLoader.GetDataForDay(2);

var encryptedRockPaperScissorsSimulator = new EncryptedRockPaperScissorsSimulator(day2Data);

Console.WriteLine($"Day 2 Part 1:  {encryptedRockPaperScissorsSimulator.GetPlayerTotalScore()}");

var encryptedRockPaperScissorsSimulatorAlt = new EncryptedRockPaperScissorsSimulator(day2Data, rhColStrategy: RhColStrategy.LossDrawWin);

Console.WriteLine($"Day 2 Part 2:  {encryptedRockPaperScissorsSimulatorAlt.GetPlayerTotalScore()}");

// Day 3
string day3data = DataLoader.GetDataForDay(3);
var misplacedItemFinder = new MisplacedItemFinder();

string[] part1Inputs = day3data.Split("\r\n");
int part1Answer = misplacedItemFinder.FindMisplacedItems(part1Inputs)
    .Select(z => MisplacedItemFinder.GetPriority(z))
    .Sum();

Console.WriteLine($"Day 3 Part 1:  {part1Answer}");

