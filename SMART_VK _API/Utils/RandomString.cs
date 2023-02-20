using Newtonsoft.Json;

namespace SMART_VK__API.Utils
{
    internal static class RandomString
    {
        private const string StringForRandomLetters = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbn";
        private const int StringLength = 10;

        public static string GetGeneratedRandomString()
        {
            Random random = new();
            return new string(Enumerable.Repeat(StringForRandomLetters, StringLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
