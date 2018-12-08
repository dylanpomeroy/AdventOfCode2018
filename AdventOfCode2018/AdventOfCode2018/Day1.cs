using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day1
    {
        private readonly string input;

        public Day1(string input)
        {
            this.input = input;
        }

        public int RunSolutionPart1()
        {
            return input
                .Split('\n')
                .Select(str => int.Parse(str))
                .Sum();
        }

        public int RunSolutionPart2()
        {
            var integers = input.Split('\n')
                .Select(str => int.Parse(str))
                .ToArray();

            var frequencyResults = new HashSet<int>() { 0 };
            int currentFrequency = 0;
            for (var i = 0; ; i++){
                if (i == integers.Length) i = 0;

                currentFrequency += integers[i];

                if (frequencyResults.Contains(currentFrequency))
                    return currentFrequency;

                frequencyResults.Add(currentFrequency);
            }
        }
    }
}
