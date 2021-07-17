using System;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class BackendTests
    {
        [Fact]
        public void Test1()
        {
            string testDir = "../../../media/test1/";
            List<System.IO.FileInfo> files = new()
            {
                new System.IO.FileInfo(testDir + "a.tex"),
                new System.IO.FileInfo(testDir + "b.tex")
            };
            var inputData = new FilesToCompare(files);
            var result = new BasicFileComparer(new ByLengthProblemComparer()).ProcessInput(inputData);
            Assert.Empty(result.SimilarProblemsCases);
        }
        [Fact]
        public void Test2()
        {
            string testDir = "../../../media/test2/";
            List<System.IO.FileInfo> files = new()
            {
                new System.IO.FileInfo(testDir + "a.tex"),
                new System.IO.FileInfo(testDir + "b.tex")
            };
            var inputData = new FilesToCompare(files);
            var result = new BasicFileComparer(new ByLengthProblemComparer()).ProcessInput(inputData);
            Assert.Equal(4, result.SimilarProblemsCases.Count);
        }
    }
}