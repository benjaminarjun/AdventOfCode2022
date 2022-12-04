using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Solvers.Day03;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestMisplacedItemFinder
    {
        string input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";


        [TestMethod]
        public void TestExample1FindsCorrectItems()
        {
            var expected = new List<char> { 'p', 'L', 'P', 'v', 't', 's', };
            var finder = new MisplacedItemFinder();

            string[] rucksacks = input.Split("\r\n");

            CollectionAssert.AreEqual(expected, finder.FindMisplacedItems(rucksacks));
        }

        [TestMethod]
        public void TestExample1Priorities()
        {
            // test individuals
            Assert.AreEqual(16, MisplacedItemFinder.GetPriority('p'));
            Assert.AreEqual(38, MisplacedItemFinder.GetPriority('L'));
            Assert.AreEqual(42, MisplacedItemFinder.GetPriority('P'));
            Assert.AreEqual(22, MisplacedItemFinder.GetPriority('v'));
            Assert.AreEqual(20, MisplacedItemFinder.GetPriority('t'));
            Assert.AreEqual(19, MisplacedItemFinder.GetPriority('s'));
        }
    }
}
