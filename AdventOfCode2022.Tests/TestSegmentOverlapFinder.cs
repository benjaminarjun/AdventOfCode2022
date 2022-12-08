using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Solvers.Day04;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestSegmentOverlapFinder
    {
        string input = "2-4,6-8\r\n2-3,4-5\r\n5-7,7-9\r\n2-8,3-7\r\n6-6,4-6\r\n2-6,4-8";

        [TestMethod]
        public void TestExample1FindNumberOfFullyContainingSegmentPairs()
        {
            var finder = new SegmentOverlapFinder(input);
            int expected = 2;

            Assert.AreEqual(expected, finder.GetNumFullyContainingSegmentPairs());
        }

        [TestMethod]
        public void TestExample1FindNumberOfOverlappingSegmentPairs()
        {
            var finder = new SegmentOverlapFinder(input);
            int expected = 4;

            Assert.AreEqual(expected, finder.GetNumOverlappingSegmentPairs());
        }
    }
}
