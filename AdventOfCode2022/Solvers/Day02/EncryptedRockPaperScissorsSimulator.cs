using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Solvers.Day02.RockPaperScissors;

namespace AdventOfCode2022.Solvers.Day02
{
    public class EncryptedRockPaperScissorsSimulator
    {
        public List<Tuple<Move, Move>> GameMoves { get; }

        private Dictionary<string, Move> opponentDecryptionKey = new Dictionary<string, Move>
        {
            { "A", Move.Rock },
            { "B", Move.Paper },
            { "C", Move.Scissors },
        };

        private Dictionary<string, Move> rpsPlayerDecryptionKey = new Dictionary<string, Move>
        {
            { "X", Move.Rock },
            { "Y", Move.Paper },
            { "Z", Move.Scissors },
        };

        public EncryptedRockPaperScissorsSimulator(string gameInput, RhColStrategy rhColStrategy = RhColStrategy.RockPaperScissors)
        {
            GameMoves = new List<Tuple<Move, Move>>();

            string[] gameLines = gameInput.Split("\r\n");

            foreach (string line in gameLines)
            {
                var encryptedMoves = line.Split(" ");

                Move opponentMove = GetDecryptedMove(opponentDecryptionKey, encryptedMoves[0]);
                Move playerMove;

                // Assign moves to the encrypted player move values. We can either interpret these as
                // Rock, Paper, Scissors, or the moves that lead to a Loss, Draw, or Win given the opponent's move.
                if (rhColStrategy == RhColStrategy.RockPaperScissors)
                {
                    playerMove = GetDecryptedMove(rpsPlayerDecryptionKey, encryptedMoves[1]);
                }
                else
                {
                    // This lookup maps the possible opponent move + desired outcome to the move the player must make
                    // in order to ensure that outcome.
                    var wdlLookup = new Dictionary<Tuple<Move, string>, Move>
                    {
                        { new Tuple<Move, string>(Move.Rock, "X"), Move.Scissors },
                        { new Tuple<Move, string>(Move.Rock, "Y"), Move.Rock },
                        { new Tuple<Move, string>(Move.Rock, "Z"), Move.Paper },
                        { new Tuple<Move, string>(Move.Paper, "X"), Move.Rock },
                        { new Tuple<Move, string>(Move.Paper, "Y"), Move.Paper },
                        { new Tuple<Move, string>(Move.Paper, "Z"), Move.Scissors },
                        { new Tuple<Move, string>(Move.Scissors, "X"), Move.Paper },
                        { new Tuple<Move, string>(Move.Scissors, "Y"), Move.Scissors },
                        { new Tuple<Move, string>(Move.Scissors, "Z"), Move.Rock },
                    };

                    playerMove = wdlLookup[new Tuple<Move, string>(opponentMove, encryptedMoves[1])];
                }

                GameMoves.Add(new Tuple<Move, Move>(opponentMove, playerMove));
            }
        }

        public int GetPlayerTotalScore()
        {
            int totalPoints = 0;

            var playerOutcomeScoreLookup = new Dictionary<GameOutcome, int>
            {
                { GameOutcome.Win, 6 },
                { GameOutcome.Draw, 3 },
                { GameOutcome.Lose, 0 },
            };

            var playerMoveScoreLookup = new Dictionary<Move, int>
            {
                { Move.Rock, 1 },
                { Move.Paper, 2 },
                { Move.Scissors, 3 },
            };

            foreach (Tuple<Move, Move> moveTuple in GameMoves)
            {
                Move opponentMove = moveTuple.Item1;
                Move playerMove = moveTuple.Item2;

                GameOutcome outcome = RockPaperScissorsPlayer.Play(opponentMove, playerMove);

                totalPoints += playerOutcomeScoreLookup[outcome] + playerMoveScoreLookup[playerMove];
            }

            return totalPoints;
        }

        private Move GetDecryptedMove(Dictionary<string, Move> decryptionKey, string encryptedMove)
        {
            try
            {
                return decryptionKey[encryptedMove];
            }
            catch (KeyNotFoundException ex)
            {
                string msg = $"Received invalid input {encryptedMove}; must be one of {string.Join(" ", decryptionKey.Keys)}";
                throw new Exception(msg, ex);
            }
        }
    }
}
