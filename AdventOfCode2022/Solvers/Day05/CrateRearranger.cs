using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day05
{
    public class CrateRearranger
    {
        public Dictionary<int, Stack<char>> Stacks { get; private set; }

        public List<StackMove> StackMoves { get; private set; }

        private CraneModel craneModel;

        public CrateRearranger(string input, CraneModel model = CraneModel.CrateMover9000)
        {
            ParseInput(input);
            craneModel = model;
        }

        private void ParseInput(string input)
        {
            Stacks = new Dictionary<int, Stack<char>>();

            string[] lines = input.Split("\r\n");

            int sepIx = lines
                .Select((line, ix) => (line, ix))
                .Where(z => string.IsNullOrEmpty(z.line))
                .Select(z => z.ix)
                .First();

            int stackNumLineIx = sepIx - 1;
            string stackNumLine = lines[stackNumLineIx];

            // this gets the location of each stack num in the final line of the crate stack drawing.
            // Assume these will also be the locations of the crates in the lines above. There's no
            // specified behavior for multi-digit crate stacks so assume they're single digit and there's
            // no ambiguity about where about the crate stack is above its index.
            IEnumerable<int> stackIndexes = stackNumLine
                .ToCharArray()
                .Select((c, ix) => (c, ix))
                .Where(z => z.c != ' ')
                .Select(z => z.ix);

            int i = 1;
            foreach (int stackIndex in stackIndexes)
            {
                IEnumerable<char> stackElements = lines.Take(stackNumLineIx)
                    .Reverse()
                    .Select(line => line[stackIndex])
                    .Where(c => c != ' ');

                var thisStack = new Stack<char>(stackElements);
                Stacks[i] = thisStack;

                i += 1;
            }

            // now get the set of moves from the input.
            StackMoves = new List<StackMove>();

            int numMoveLines = lines.Count() - sepIx;
            foreach (string line in lines.Skip(sepIx + 1).Take(numMoveLines))
            {
                string delim = "|";

                // Remove words or replace with a delimiter we can split on
                string modifiedLine = line.Replace("move ", "");
                modifiedLine = modifiedLine.Replace(" from ", delim);
                modifiedLine = modifiedLine.Replace(" to ", delim);

                int[] vals = modifiedLine.Split(delim).Select(z => Convert.ToInt32(z)).ToArray();

                StackMoves.Add(new StackMove(vals[0], vals[1], vals[2]));
            }
        }

        public void Rearrange()
        {
            foreach (StackMove move in StackMoves)
            {
                if (craneModel == CraneModel.CrateMover9000)
                {
                    PerformSingleCrateMove(move);
                }
                else
                {
                    PerformMultiCrateMove(move);
                }
            }
        }

        private void PerformSingleCrateMove(StackMove move)
        {
            // for the CrateModel9000

            for (int i = 0; i < move.NumToMove; i++)
            {
                char crate = Stacks[move.FromIndex].Pop();
                Stacks[move.ToIndex].Push(crate);
            }
        }

        private void PerformMultiCrateMove(StackMove move)
        {
            // for the CrateModel900

            var intermediate = new Stack<char>();
            for (int i = 0; i < move.NumToMove; i++)
            {
                char crate = Stacks[move.FromIndex].Pop();
                intermediate.Push(crate);
            }

            for (int i = 0; i < move.NumToMove; i++)
            {
                char crate = intermediate.Pop();
                Stacks[move.ToIndex].Push(crate);
            }
        }
    }
}
