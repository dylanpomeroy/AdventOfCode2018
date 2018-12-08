using AdventOfCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    [TestClass]
    public class Day2Tests
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day2")]
        public void Day2Part1Test() 
        {
            new List<(string inputFilePath, int expectedResult)> 
            {
                (inputFilePath: "Inputs/Day2/inputSample0.txt", expectedResult: 12),
                (inputFilePath: "Inputs/Day2/input0.txt", expectedResult: 6200)
            }
            .ForEach(testInfo =>
            {
                var inputData = this.ReadAllText(testInfo.inputFilePath);
                var solution = new Day2(inputData);

                var result = solution.RunSolutionPart1();
                Assert.AreEqual(
                    testInfo.expectedResult,
                    result,
                    $"Failed on {testInfo.ToString()}");
            });
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day2")]
        public void Day2Part2Test()
        {
            new List<(string inputFilePath, string expectedResult)>
            {
                (inputFilePath: "Inputs/Day2/inputSample1.txt", expectedResult: "fgij"),
                (inputFilePath: "Inputs/Day2/input0.txt", expectedResult: "xpysnnkqrbuhefmcajodplyzw")
            }
            .ForEach(testInfo =>
            {
                var inputData = this.ReadAllText(testInfo.inputFilePath);
                var solution = new Day2(inputData);

                var result = solution.RunSolutionPart2();
                Assert.AreEqual(
                    testInfo.expectedResult,
                    result,
                    $"Failed on {testInfo.ToString()}");
            });
        }

        private string ReadAllText(string filePath)
        {
            if (System.IO.File.Exists(filePath))
                return System.IO.File.ReadAllText(filePath);
            else
                return System.IO.File.ReadAllText(filePath.Split('/').Last());
        }
    }
}
