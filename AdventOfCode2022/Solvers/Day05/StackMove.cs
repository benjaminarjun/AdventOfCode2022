using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day05
{
    public class StackMove
    {
        public int NumToMove { get; set; }
        public int FromIndex { get; set; }
        public int ToIndex { get; set; }

        public StackMove(int numToMove, int fromIndex, int toIndex)
        {
            NumToMove = numToMove;
            FromIndex = fromIndex;
            ToIndex = toIndex;
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() == this.GetType())
            {
                var stackMoveObj = (StackMove)obj;

                return
                    this.NumToMove == stackMoveObj.NumToMove
                    && this.FromIndex == stackMoveObj.FromIndex
                    && this.ToIndex == stackMoveObj.ToIndex;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (this.NumToMove ^ this.FromIndex ^ this.ToIndex).GetHashCode();
        }
    }
}
