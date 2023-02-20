using SMART_VK__API.Models;
using SMART_VK__API.TestData;

namespace SMART_VK__API.Utils
{
    internal static class TestConfigManager
    {
        private const string PathToTestConfig = @"Resources\testConfig.json";
        private const string PathToUserData = @"Resources\userData.json";

        public static readonly TestConfig? testConfig = FileReader.ReadJsonData<TestConfig>(PathToTestConfig);
        public static readonly UserData? userData = FileReader.ReadJsonData<UserData>(PathToUserData);
    }
}
