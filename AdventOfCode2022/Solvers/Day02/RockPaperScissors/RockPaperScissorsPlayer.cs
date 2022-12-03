using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day02.RockPaperScissors
{
    internal static class RockPaperScissorsPlayer
    {
        internal static GameOutcome Play(Move opponentMove, Move playerMove)
        {
            var outcomeLookup = new Dictionary<Tuple<Move, Move>, GameOutcome>
            {
                { new Tuple<Move, Move>(Move.Rock, Move.Rock), GameOutcome.Draw },
                { new Tuple<Move, Move>(Move.Rock, Move.Paper), GameOutcome.Win },
                { new Tuple<Move, Move>(Move.Rock, Move.Scissors), GameOutcome.Lose },
                { new Tuple<Move, Move>(Move.Paper, Move.Rock), GameOutcome.Lose },
                { new Tuple<Move, Move>(Move.Paper, Move.Paper), GameOutcome.Draw },
                { new Tuple<Move, Move>(Move.Paper, Move.Scissors), GameOutcome.Win },
                { new Tuple<Move, Move>(Move.Scissors, Move.Rock), GameOutcome.Win },
                { new Tuple<Move, Move>(Move.Scissors, Move.Paper), GameOutcome.Lose },
                { new Tuple<Move, Move>(Move.Scissors, Move.Scissors), GameOutcome.Draw },
            };

            return outcomeLookup[new Tuple<Move, Move>(opponentMove, playerMove)];
        }
    }
}
