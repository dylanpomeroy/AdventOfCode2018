using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018
{
    public class Day3
    {
        private readonly string input;

        public Day3(string input)
        {
            this.input = input;
        }

        public int RunSolutionPart1()
        {
            var elfClaims = input.Split('\n')
                .Select(claimString => new ElfClaim(claimString))
                .ToDictionary(claim => claim.Id, claim => claim);

            var maxBoundWidth = elfClaims.Select(claim => claim.Value.GetBoundWidth()).Max();
            var maxBoundHeight = elfClaims.Select(claim => claim.Value.GetBoundHeight()).Max();

            var fabric = new int[maxBoundWidth + 1, maxBoundHeight + 1];

            foreach (var elfClaim in elfClaims.Values)
            {
                for (int currWidth = 0; currWidth < elfClaim.Width; currWidth++)
                {
                    for (int currHeight = 0; currHeight < elfClaim.Height; currHeight++)
                    {
                        var firstIndex = elfClaim.InchesFromLeft + currWidth;
                        var secondIndex = elfClaim.InchesFromTop + currHeight;

                        fabric[firstIndex, secondIndex]++;
                    }
                }
            }

            var result = 0;
            for (int i = 0; i < fabric.GetLength(0); i++)
            {
                for (int j = 0; j < fabric.GetLength(1); j++)
                {
                    if (fabric[i, j] > 1)
                        result++;
                }
            }

            return result;
        }
        
        public int RunSolutionPart2()
        {
            var elfClaims = input.Split('\n')
                .Select(claimString => new ElfClaim(claimString))
                .ToDictionary(claim => claim.Id, claim => claim);

            var maxBoundWidth = elfClaims.Select(claim => claim.Value.GetBoundWidth()).Max();
            var maxBoundHeight = elfClaims.Select(claim => claim.Value.GetBoundHeight()).Max();

            var fabric = new int[maxBoundWidth + 1, maxBoundHeight + 1];

            foreach (var elfClaim in elfClaims.Values)
            {
                for (int currWidth = 0; currWidth < elfClaim.Width; currWidth++)
                {
                    for (int currHeight = 0; currHeight < elfClaim.Height; currHeight++)
                    {
                        var firstIndex = elfClaim.InchesFromLeft + currWidth;
                        var secondIndex = elfClaim.InchesFromTop + currHeight;

                        if (fabric[firstIndex, secondIndex] == 0)
                            fabric[firstIndex, secondIndex] = elfClaim.Id;
                        else
                        {
                            if (fabric[firstIndex, secondIndex] != -1)
                                elfClaims[fabric[firstIndex, secondIndex]].Overlapping = true;

                            elfClaim.Overlapping = true;
                            fabric[firstIndex, secondIndex] = -1;
                        }
                    }
                }
            }

            return elfClaims.Where(claim => !claim.Value.Overlapping).First().Value.Id;
        }

        internal class ElfClaim
        {
            public ElfClaim(string parsingString)
            {
                var data = parsingString.Split(' ');
                Id = int.Parse(data[0].TrimStart('#'));
                InchesFromLeft = int.Parse(data[2].Split(',')[0]);
                InchesFromTop = int.Parse(data[2].Split(',')[1].TrimEnd(':'));
                Width = int.Parse(data[3].Split('x')[0]);
                Height = int.Parse(data[3].Split('x')[1]);

                Overlapping = false;
            }

            public int GetBoundWidth()
            {
                return InchesFromLeft + Width;
            }

            public int GetBoundHeight()
            {
                return InchesFromTop + Height;
            }

            public int Id { get; set; }
            public int InchesFromLeft { get; set; }
            public int InchesFromTop { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public bool Overlapping { get; set; }
        }
    }
}
