using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day06
{
    public class CommDevice
    {
        public int StartOfPacketMarkerEnd { get; }

        public int StartOfMessageMarkerEnd { get; }

        private string buffer;

        public CommDevice(string buffer)
        {
            this.buffer = buffer;

            // identify markers and record the indexes of their last characters
            StartOfPacketMarkerEnd = FindMarkerEnd(4);
            StartOfMessageMarkerEnd = FindMarkerEnd(14);
        }

        private int FindMarkerEnd(int markerLen)
        {
            int i = 0;

            while (i + markerLen < this.buffer.Length)
            {
                string thisChunk = buffer.Substring(i, markerLen);

                int numDistinct = thisChunk
                    .ToCharArray()
                    .Distinct()
                    .Count();

                if (numDistinct == markerLen)
                {
                    return i + markerLen;
                }

                i++;
            }

            throw new Exception($"Could not find a marker of specified length {markerLen} in the buffer.");
        }
    }
}