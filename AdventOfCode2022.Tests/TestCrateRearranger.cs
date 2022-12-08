using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Solvers.Day05;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestCrateRearranger
    {
        string input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

        [TestMethod]
        public void TestExample1InputParsesCorrectly()
        {
            var rearranger = new CrateRearranger(input);

            var cratesExpected = new Dictionary<int, Stack<char>>
            {
                { 1, new Stack<char>(new char[] { 'Z', 'N' }) },
                { 2, new Stack<char>(new char[] { 'M', 'C', 'D' }) },
                { 3, new Stack<char>(new char[] { 'P' }) },
            };

            // check the crate stacks are equal
            CollectionAssert.AreEqual(cratesExpected.Keys, rearranger.Stacks.Keys);

            foreach (int k in cratesExpected.Keys)
            {
                CollectionAssert.AreEqual(cratesExpected[k], rearranger.Stacks[k]);
            }

            // check the queued moves are equal
            var movesExpected = new List<StackMove>
            {
                new StackMove(1, 2, 1),
                new StackMove(3, 1, 3),
                new StackMove(2, 2, 1),
                new StackMove(1, 1, 2),
            };

            CollectionAssert.AreEqual(movesExpected, rearranger.StackMoves);
        }

        [TestMethod]
        public void TestExample1ConfirmStateAfterApplyingMoves()
        {
            var rearranger = new CrateRearranger(input);
            rearranger.Rearrange();

            char stack1Expected = 'C';
            char stack2Expected = 'M';
            char stack3Expected = 'Z';

            Assert.AreEqual(stack1Expected, rearranger.Stacks[1].Peek());
            Assert.AreEqual(stack2Expected, rearranger.Stacks[2].Peek());
            Assert.AreEqual(stack3Expected, rearranger.Stacks[3].Peek());
        }
    }
}
