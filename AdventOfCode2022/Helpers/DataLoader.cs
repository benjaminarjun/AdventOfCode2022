using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Helpers
{
    public static class DataLoader
    {
        public static string GetDataForDay(int day)
        {
            if (day < 1 || day > 25)
            {
                throw new Exception($"Cannot fetch data for day {day}; input must be between 1 and 25.");
            }

            string pathToData = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                $"day{day.ToString().PadLeft(2, '0')}.txt"
            );

            try
            {
                return File.ReadAllText(pathToData);
            }
            catch (FileNotFoundException ex)
            {
                throw new Exception($"Could not find data file {pathToData} for specified day {day}.", ex);
            }
        }
    }
}
