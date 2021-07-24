using Xunit;

namespace tests
{
    public class ConfigReaderTests
    {
        [Fact]
        public void ReadConfig_JsonHasVerboseLevel_ReadCorrectly()
        {
            string testDir = "../../../media/test7";
            Config config = ConfigReader.ReadConfig(System.IO.Path.Combine(testDir, "texelperconfig.json")).Extract();
            Assert.Equal(LogVerbosity.Verbose, config.LogVerbosity);
        }
    }
}