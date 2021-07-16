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
            Assert.Equal(2, fstProbs.Count);
            Assert.Equal(2, sndProbs.Count);
            Assert.True(new DummyProblemComparer().AreTwoProblemsSimilar(fstProbs[0],
                fstProbs[1]));
            Assert.False(new DummyProblemComparer().AreTwoProblemsSimilar(fstProbs[0],
                sndProbs[0]));
        }
    }
}