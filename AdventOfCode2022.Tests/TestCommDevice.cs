using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Solvers.Day06;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestCommDevice
    {
        [TestMethod]
        public void TestFindStartOfPacketMarker()
        {
            var testCases = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7),
                new Tuple<string, int>("bvwbjplbgvbhsrlpgdmjqwftvncz", 5),
                new Tuple<string, int>("nppdvjthqldpwncqszvftbrmjlhg", 6),
                new Tuple<string, int>("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10),
                new Tuple<string, int>("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11),
            };

            foreach (Tuple<string, int> testCase in testCases)
            {
                (string input, int expected) = testCase;

                var commDevice = new CommDevice(input);
                Assert.AreEqual(expected, commDevice.StartOfPacketMarkerEnd);
            }
        }

        [TestMethod]
        public void TestFindStartOfMessageMarker()
        {
            var testCases = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19),
                new Tuple<string, int>("bvwbjplbgvbhsrlpgdmjqwftvncz", 23),
                new Tuple<string, int>("nppdvjthqldpwncqszvftbrmjlhg", 23),
                new Tuple<string, int>("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29),
                new Tuple<string, int>("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26),
            };

            foreach (Tuple<string, int> testCase in testCases)
            {
                (string input, int expected) = testCase;

                var commDevice = new CommDevice(input);
                Assert.AreEqual(expected, commDevice.StartOfMessageMarkerEnd);
            }
        }
    }
}
