using AdventOfCode2022.Solvers;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestCalorieCounter
    {
        string input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

        [TestMethod]
        public void TestExample1ListsMatch()
        {
            var counter = new CalorieCounter(input);
            var expected = new List<int> { 6000, 4000, 11000, 24000, 10000 };

            CollectionAssert.AreEqual(expected, counter.CalorieCounts);
        }

        [TestMethod]
        public void TestExample1PicksCorrectValue()
        {
            var counter = new CalorieCounter(input);
            int expected = 24000;

            Assert.AreEqual(expected, counter.GetMax());
        }

        [TestMethod]
        public void TestExample1()
        {
            var counter = new CalorieCounter(input);
            var expected = new List<int> { 24000, 11000, 10000, };

            CollectionAssert.AreEquivalent(expected, counter.GetTop(3));
        }
    }
}