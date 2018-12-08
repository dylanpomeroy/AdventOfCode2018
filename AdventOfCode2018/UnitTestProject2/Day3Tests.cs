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
    public class Day3Tests
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day3", "Inputs/Day3")]
        public void Day3Part1Test() 
        {
            new List<(string inputFilePath, int expectedResult)> 
            {
                (inputFilePath: "Inputs/Day3/inputSample0.txt", expectedResult: 4),
                (inputFilePath: "Inputs/Day3/input0.txt", expectedResult: 111630),
            }
            .ForEach(testInfo =>
            {
                var inputData = this.ReadAllText(testInfo.inputFilePath);
                var solution = new Day3(inputData);

                var result = solution.RunSolutionPart1();
                Assert.AreEqual(
                    testInfo.expectedResult,
                    result,
                    $"Failed on {testInfo.ToString()}");
            });
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day3", "Inputs/Day3")]
        public void Day3Part2Test()
        {
            new List<(string inputFilePath, int expectedResult)>
            {
                (inputFilePath: "Inputs/Day3/inputSample0.txt", expectedResult: 3),
                (inputFilePath: "Inputs/Day3/input0.txt", expectedResult: 724),
            }
            .ForEach(testInfo =>
            {
                var inputData = this.ReadAllText(testInfo.inputFilePath);
                var solution = new Day3(inputData);

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
