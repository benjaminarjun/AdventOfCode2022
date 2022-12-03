using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers
{
    public class CalorieCounter
    {
        public List<int> CalorieCounts;

        public CalorieCounter(string calorieCountsRaw)
        {
            var calorieCounts = new List<int>();

            // need to keep track of whether the previous line was a calorie count or an empty line so we know whether there's a last elf to account for
            // once we reach the end of the list - just in case the last value is a 0
            bool currentlyAccumulating = false;
            int sum = 0;

            foreach (string line in calorieCountsRaw.Split("\r\n"))
            {
                currentlyAccumulating = !string.IsNullOrEmpty(line);

                if (!currentlyAccumulating)
                {
                    calorieCounts.Add(sum);
                    sum = 0;
                }
                else
                {
                    sum += Convert.ToInt32(line);
                }
            }

            if (currentlyAccumulating)
            {
                calorieCounts.Add(sum);
            }

            this.CalorieCounts = calorieCounts;
        }

        public int GetMax()
        {
            return CalorieCounts.Max();
        }

        public List<int> GetTop(int num)
        {
            return CalorieCounts.OrderByDescending(z => z).Take(num).ToList();
        }
    }
}
