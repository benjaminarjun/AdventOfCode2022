using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Solvers.Day02;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestEncryptedRockPaperScissorsSimulator
    {
        string input = "A Y\r\nB X\r\nC Z";

        [TestMethod]
        public void TestExample1TotalScore()
        {
            var simulator = new EncryptedRockPaperScissorsSimulator(input);

            int expected = 15;
            int totalScore = simulator.GetPlayerTotalScore();

            Assert.AreEqual(expected, totalScore);
        }

        [TestMethod]
        public void TestExample1WithAlternateRhColInterpretation()
        {
            var simulator = new EncryptedRockPaperScissorsSimulator(input, rhColStrategy: RhColStrategy.LossDrawWin);

            int expected = 12;
            int totalScore = simulator.GetPlayerTotalScore();

            Assert.AreEqual(expected, totalScore);
        }
    }
}
