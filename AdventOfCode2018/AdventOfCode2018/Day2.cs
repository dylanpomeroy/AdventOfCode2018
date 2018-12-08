using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day2
    {
        private readonly string input;

        public Day2(string input)
        {
            this.input = input;
        }

        public int RunSolutionPart1()
        {
            var boxIds = input.Split('\n');
            var twoCount = 0;
            var threeCount = 0;

            foreach (var boxId in boxIds)
            {
                var frequencyDictionary = new Dictionary<char, int>();
                foreach (var boxIdCharacter in boxId)
                {
                    if (!frequencyDictionary.ContainsKey(boxIdCharacter))
                        frequencyDictionary[boxIdCharacter] = 1;
                    else
                        frequencyDictionary[boxIdCharacter]++;
                }

                if (frequencyDictionary.Any(kvp => kvp.Value == 2))
                    twoCount++;
                if (frequencyDictionary.Any(kvp => kvp.Value == 3))
                    threeCount++;
            }

            return twoCount * threeCount;
        }

        public string RunSolutionPart2()
        {
            var boxIds = input.Split('\n');

            for (var i = 0; i < boxIds.Length; i++)
            {
                var id1 = boxIds[i];
                for (var j = i + 1; j < boxIds.Length; j++)
                {
                    var charsOff = 0;
                    var id2 = boxIds[j];

                    for (int k = 0; k < id1.Length; k++)
                    {
                        if (id1[k] != id2[k])
                            charsOff++;

                        if (charsOff > 1)
                            break;
                    }

                    if (charsOff == 1)
                    {
                        var result = string.Empty;
                        for (var l = 0; l < id1.Length; l++)
                        {
                            if (id1[l] == id2[l])
                                result += id1[l];
                        }

                        return result;
                    }
                }
            }

            return null;
        }
    }
}
