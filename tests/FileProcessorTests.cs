using System;
using Xunit;

namespace tests
{
    public class FileProcessorTests
    {
        [Fact]
        public void Test1()
        {
            string testDir = "../../../media/test1/";
            var fstProbs = FileProcessor.ReadFile(new System.IO.FileInfo(testDir + "a.tex"));
            var sndProbs = FileProcessor.ReadFile(new System.IO.FileInfo(testDir + "b.tex"));
            Assert.Equal(fstProbs.Count, 2);
            Assert.Equal(sndProbs.Count, 2);
            Assert.True(new DummyProblemComparer().AreTwoProblemsSimilar(fstProbs[0],
                fstProbs[1]));
        }
    }
}