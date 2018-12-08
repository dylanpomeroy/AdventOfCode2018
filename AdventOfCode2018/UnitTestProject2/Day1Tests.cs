using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2018;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class Day1Tests
    {
        [TestMethod]
        [DeploymentItem("Inputs/Day1")]
        public void Day1Part1Test()
        {
            var testData = this.ReadAllText("Inputs/Day1/input0.txt");
            var day1 = new Day1(testData);

            var returnValue = day1.RunSolutionPart1();
            Assert.AreEqual(590, returnValue);
        }

        [TestMethod]
        [DeploymentItem("Inputs/Day1")]
        public void Day1Part2Test()
        {
            new List<(string inputFilePath, int expectedResult)>
            {
                (inputFilePath: "Inputs/Day1/inputSample0.txt", expectedResult: 0),
                (inputFilePath: "Inputs/Day1/inputSample1.txt", expectedResult: 10),
                (inputFilePath: "Inputs/Day1/inputSample2.txt", expectedResult: 5),
                (inputFilePath: "Inputs/Day1/inputSample3.txt", expectedResult: 14),
                (inputFilePath: "Inputs/Day1/input0.txt", expectedResult: 83445)
            }
            .ForEach(testInfo =>
            {
                var inputData = this.ReadAllText(testInfo.inputFilePath);
                var solution = new Day1(inputData);

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
