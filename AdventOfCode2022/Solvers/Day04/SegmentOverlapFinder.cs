using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day04
{
    public class SegmentOverlapFinder
    {
        public List<Tuple<Segment, Segment>> SegmentPairs { get; }

        public SegmentOverlapFinder(string input)
        {
            SegmentPairs = new List<Tuple<Segment, Segment>>();

            string[] segmentPairsRaw = input.Split("\r\n");

            foreach (string pair in segmentPairsRaw)
            {
                // a pair of raw segments
                string[] segmentsRaw = pair.Split(",");
                // "1-4"
                Segment[] segments = segmentsRaw
                    .Select(z => z.Split("-"))
                    .Select(z => new Segment
                    {
                        Start = Convert.ToInt32(z[0]),
                        End = Convert.ToInt32(z[1]),
                    })
                    .ToArray();

                var segmentPair = new Tuple<Segment, Segment>(segments[0], segments[1]);
                SegmentPairs.Add(segmentPair);
            }
        }

        public int GetNumFullyContainingSegmentPairs()
        {
            return SegmentPairs
                .Where(z => z.Item1.Contains(z.Item2) || z.Item2.Contains(z.Item1))
                .Count();
        }
        public int GetNumOverlappingSegmentPairs()
        {
            return SegmentPairs
                .Where(z => z.Item1.OverlapsWith(z.Item2))
                .Count();
        }
    }
}
