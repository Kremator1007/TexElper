using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class BackendTests
    {
        [Theory]
        [InlineData(0, "test1/")]
        [InlineData(4, "test2/")]
        public void CompareFiles_BasicFunctionality_CountsProperly(
            int expectedNumOfSimilarities,
            string pathRelativeToMedia)
        {
            var inputData = ReadABFilesFromDir(pathRelativeToMedia);
            var result = new BasicFileComparer(new ByLengthProblemComparer()).CompareFiles(inputData);
            Assert.Equal(expectedNumOfSimilarities, result.SimilarProblemsCases.Count);
        }

        [Theory]
        [InlineData(1, "test3/")]
        [InlineData(1, "test4/")]
        public void CompareFiles_ReadFilesOnLineBreaks_CountsProperly(
            int expectedNumOfSimilarities,
            string pathRelativeToMedia)
        {
            var inputData = ReadABFilesFromDir(pathRelativeToMedia);
            var result = new BasicFileComparer(new ByLengthProblemComparer()).CompareFiles(inputData);
            Assert.Equal(expectedNumOfSimilarities, result.SimilarProblemsCases.Count);
        }

        private static FilesToCompare ReadABFilesFromDir(string pathRelativeToMedia)
        {
            string testDir = System.IO.Path.Combine("../../../media/", pathRelativeToMedia);
            List<string> files = new()
            {
                System.IO.Path.Combine(testDir, "a.tex"),
                System.IO.Path.Combine(testDir, "b.tex")
            };
            return new FilesToCompare(files);
        }
    }
}