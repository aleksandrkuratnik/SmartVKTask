using Newtonsoft.Json;

namespace SMART_VK__API.Utils
{
    internal static class Util
    {
        public static string GetTrimString(string strForTrim, string separator)
        {
            string upgradedString = strForTrim.Split(separator).Last();
            return upgradedString;
        }
    }
}
