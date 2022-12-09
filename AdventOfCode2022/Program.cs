using AdventOfCode2022.Helpers;
using AdventOfCode2022.Solvers.Day01;
using AdventOfCode2022.Solvers.Day02;
using AdventOfCode2022.Solvers.Day03;
using AdventOfCode2022.Solvers.Day04;
using AdventOfCode2022.Solvers.Day05;
using AdventOfCode2022.Solvers.Day06;


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
var misplacedItemFinder = new MisplacedItemFinder(day3data);

int part1Answer = misplacedItemFinder.FindMisplacedItems()
    .Select(z => MisplacedItemFinder.GetPriority(z))
    .Sum();

int part2Answer = misplacedItemFinder.FindIdentityBadges()
    .Select(z => MisplacedItemFinder.GetPriority(z))
    .Sum();

Console.WriteLine($"Day 3 Part 1:  {part1Answer}");
Console.WriteLine($"Day 3 Part 2:  {part2Answer}");

// Day 4
string day4Data = DataLoader.GetDataForDay(4);
var overlapFinder = new SegmentOverlapFinder(day4Data);

Console.WriteLine($"Day 4 Part 1:  {overlapFinder.GetNumFullyContainingSegmentPairs()}");
Console.WriteLine($"Day 4 Part 2:  {overlapFinder.GetNumOverlappingSegmentPairs()}");

// Day 5
string day5Data = DataLoader.GetDataForDay(5);
var rearranger = new CrateRearranger(day5Data);
rearranger.Rearrange();

IEnumerable<char> topCrateEachStack = rearranger.Stacks
    .Select(kvp => new { ix = kvp.Key, value = kvp.Value.Peek() })
    .OrderBy(z => z.ix)
    .Select(z => z.value);

string topCrateEachStackStr = string.Join("", topCrateEachStack);

Console.WriteLine($"Day 5 Part 1:  {topCrateEachStackStr}");

var fancyRearranger = new CrateRearranger(day5Data, model: CraneModel.CrateMover9001);
fancyRearranger.Rearrange();

IEnumerable<char> fancyTopCrateEachStack = fancyRearranger.Stacks
    .Select(kvp => new { ix = kvp.Key, value = kvp.Value.Peek() })
    .OrderBy(z => z.ix)
    .Select(z => z.value);

string fancyTopCrateEachStackStr = string.Join("", fancyTopCrateEachStack);

Console.WriteLine($"Day 5 Part 2:  {fancyTopCrateEachStackStr}");

// Day 6

string day6Data = DataLoader.GetDataForDay(6);
var commDevice = new CommDevice(day6Data);

Console.WriteLine($"Day 6 Part 1:  {commDevice.StartOfPacketMarkerEnd}");
Console.WriteLine($"Day 6 Part 2:  {commDevice.StartOfMessageMarkerEnd}");
