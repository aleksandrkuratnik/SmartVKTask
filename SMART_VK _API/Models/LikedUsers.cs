using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class LikedUsers
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("copied")]
        public int Copied { get; set; }
    }
}
