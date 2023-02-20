using Newtonsoft.Json;
using RestSharp;

namespace SMART_VK__API.Utils;

internal static class ModelDeserializer
{
    public static T? DeserializeModel<T>(RestResponse response)
    {
        string? jsonString = response.Content;
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
