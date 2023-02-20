using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class ImageResponse
    {
        [JsonProperty("server")]
        public int Server { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
