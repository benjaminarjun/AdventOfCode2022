using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solvers.Day03
{
    public class MisplacedItemFinder
    {
        public string[] Rucksacks { get; }

        public MisplacedItemFinder(string rucksacksRaw)
        {
            Rucksacks = rucksacksRaw.Split("\r\n");

            if (Rucksacks.Length % 3 != 0)
            {
                throw new Exception("List of rucksacks must have length divisible by 3.");
            }
        }

        char FindMisplacedItem(string rucksack)
        {
            if (rucksack.Length % 2 != 0)
            {
                throw new Exception($"Rucksack input {rucksack} does not have an even length; must be even to properly partition.");
            }

            int partitionLength = rucksack.Length / 2;

            string partition1 = rucksack.Substring(0, partitionLength);
            string partition2 = rucksack.Substring(partitionLength, partitionLength);

            char misplacedItem = partition1
                .ToArray()
                .Where(z => partition2.Contains(z))
                .Distinct()
                .Single();

            return misplacedItem;
        }

        public List<char> FindMisplacedItems()
        {
            return Rucksacks.Select(r => FindMisplacedItem(r)).ToList();
        }

        public static int GetPriority(char c)
        {
            if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                throw new Exception($"Received invalid input {c}; must be in [a-zA-Z]");
            }

            // determine whether upper or lower so we know by what amout to offset the int value
            int offset;
            if (c.ToString() == c.ToString().ToUpper())
            {
                offset = (int)'A' - 26;
            }
            else
            {
                offset = (int)'a';
            }

            // subtract 1 so we get 1-indexing on the priority
            offset -= 1;

            return (int)c - offset;
        }

        public static char FindIdentityBadge(string rucksack1, string rucksack2, string rucksack3)
        {
            return rucksack1
                .ToArray()
                .Where(z => rucksack2.Contains(z) && rucksack3.Contains(z))
                .Distinct()
                .Single();
        }

        public List<char> FindIdentityBadges()
        {
            int i = 0;
            var identityBadges = new List<char>();

            while (i < Rucksacks.Length)
            {
                char badge = MisplacedItemFinder.FindIdentityBadge(
                    Rucksacks[i],
                    Rucksacks[i + 1],
                    Rucksacks[i + 2]
                );

                identityBadges.Add(badge);

                i += 3;
            }

            return identityBadges;
        }
    }
}
