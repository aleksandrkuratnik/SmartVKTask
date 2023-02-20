using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class SavedImageResponse
    {
        [JsonProperty("response")]

        public List<Image> Response { get; set; }
    }
}
