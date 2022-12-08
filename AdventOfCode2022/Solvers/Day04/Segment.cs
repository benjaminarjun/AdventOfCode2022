using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day04
{
    public class Segment
    {
        public int Start { get; set; }
        public int End { get; set; }

        public bool Contains(Segment other)
        {
            return this.Start <= other.Start && this.End >= other.End;
        }

        public bool OverlapsWith(Segment other)
        {
            return (this.Start <= other.End && this.End >= other.Start);
        }
    }
}
