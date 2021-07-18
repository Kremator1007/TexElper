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
            var fstProbs = TexFileReader.ReadFile(testDir + "a.tex");
            var sndProbs = TexFileReader.ReadFile(testDir + "b.tex");
            Assert.Equal(2, fstProbs.Count);
            Assert.Equal(2, sndProbs.Count);
            Assert.True(new ByLengthProblemComparer().AreTwoProblemsSimilar(fstProbs[0],
                fstProbs[1]));
            Assert.False(new ByLengthProblemComparer().AreTwoProblemsSimilar(fstProbs[0],
                sndProbs[0]));
        }
    }
}