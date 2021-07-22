using System;
using Xunit;

namespace tests
{
    public class FileProcessorTests
    {
        [Theory]
        [InlineData("test1/a.tex", 2)]
        [InlineData("test1/b.tex", 2)]
        public void ReadFile_NormalProblemLists_ReturnsProperAmountOfProblems(
            string fileRelativePath,
            int expectedNumOfProblems
            )
        {
            const string testDir = "../../../media/";
            var problems = TexFileReader.ReadFile(testDir + fileRelativePath);
            Assert.Equal(expectedNumOfProblems, problems.Count);
        }

        [Fact]
        public void ReadFile_ProblemsHaveLineBreaks_ReturnsProperAmountOfProblems()
        {
            const string testDir = "../../../media/test1/";
            var probs = TexFileReader.ReadFile(testDir + "c.tex");
            Assert.Equal(3, probs.Count);
        }
    }
}