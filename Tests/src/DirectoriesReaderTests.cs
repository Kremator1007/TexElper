using Xunit;

namespace tests
{
    public class DirectoriesTests
    {
        [Fact]
        public void SelectFilesByDirectory_OnlyTexFile_ProperlyCounts()
        {
            const string path = "../../../media/test5";
            var filesSelector = new FilesByDirectoriesSelector(
                new ConstantDirectoriesSelector(new string[] { path })
            );
            var files = filesSelector.SelectFilesForFindingSimilarProblems();
            Assert.Equal(5, files.AllRelevantFiles.Count);
        }
        [Fact]
        public void SelectFilesByDirectory_NotOnlyTexFile_ProperlyCounts()
        {
            const string path = "../../../media/test6";
            var filesSelector = new FilesByDirectoriesSelector(
                new ConstantDirectoriesSelector(new string[] { path })
            );
            var files = filesSelector.SelectFilesForFindingSimilarProblems();
            Assert.Equal(5, files.AllRelevantFiles.Count);
        }
    }
}