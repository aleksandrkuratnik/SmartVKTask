using Newtonsoft.Json;

namespace SMART_VK__API.Utils
{
    internal class FileReader
    {
        public static T? ReadJsonData<T>(string path)
        {
            return JsonConvert.DeserializeObject<T>(ReadFile(path));
        }

        private static string ReadFile(string path)
        {
            using StreamReader sr = new StreamReader(path);
            return sr.ReadToEnd();
        }
    }
}
