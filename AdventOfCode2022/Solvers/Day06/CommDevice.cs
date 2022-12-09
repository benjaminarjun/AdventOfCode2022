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

        private string buffer;

        public CommDevice(string buffer)
        {
            this.buffer = buffer;

            // default this to -1 so we can check its value without errors
            StartOfPacketMarkerEnd = -1;
            
            // identify the start-of-packet-marker and record the index of its last character
            int i = 0;
            int startOfPacketMarkerLength = 4;

            while (StartOfPacketMarkerEnd < 0)
            {
                string thisChunk = buffer.Substring(i, startOfPacketMarkerLength);

                int numDistinct = thisChunk
                    .ToCharArray()
                    .Distinct()
                    .Count();

                if (numDistinct == startOfPacketMarkerLength)
                {
                    StartOfPacketMarkerEnd = i + startOfPacketMarkerLength;
                }

                i++;
            }
        }
    }
}
