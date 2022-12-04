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
            var finder = new MisplacedItemFinder(input);

            CollectionAssert.AreEqual(expected, finder.FindMisplacedItems());
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

        [TestMethod]
        public void TestExample1FindIdentityBadge()
        {
            var finder = new MisplacedItemFinder(input);
            char badge1 = MisplacedItemFinder.FindIdentityBadge(
                finder.Rucksacks[0],
                finder.Rucksacks[1],
                finder.Rucksacks[2]
            );

            Assert.AreEqual('r', badge1);

            char badge2 = MisplacedItemFinder.FindIdentityBadge(
                finder.Rucksacks[3],
                finder.Rucksacks[4],
                finder.Rucksacks[5]
            );

            Assert.AreEqual('Z', badge2);
        }

        [TestMethod]
        public void TestExample1FindIdentityBadges()
        {
            var expected = new List<char> { 'r', 'Z' };
            var finder = new MisplacedItemFinder(input);

            CollectionAssert.AreEqual(expected, finder.FindIdentityBadges());
        }
    }
}
