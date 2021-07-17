using System;
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
        public void CompareFiles_ReadFilesOnLineBreaks_CountsProperly(
            int expectedNumOfSimilarities,
            string pathRelativeToMedia)
        {
            var inputData = ReadABFilesFromDir(pathRelativeToMedia);
            var result = new BasicFileComparer(new ByLengthProblemComparer()).CompareFiles(inputData);
            Assert.Equal(expectedNumOfSimilarities, result.SimilarProblemsCases.Count);
        }

        private FilesToCompare ReadABFilesFromDir(string pathRelativeToMedia)
        {
            string testDir = "../../../media/" + pathRelativeToMedia;
            if (testDir[^1] != '/')
                testDir += "/";

            List<System.IO.FileInfo> files = new()
            {
                new System.IO.FileInfo(testDir + "a.tex"),
                new System.IO.FileInfo(testDir + "b.tex")
            };
            return new FilesToCompare(files);
        }
    }
}