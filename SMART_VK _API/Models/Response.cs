using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class Response
    {
        [JsonProperty("count")]
        public int count { get; set; }

        [JsonProperty("users")]
        public List<LikedUsers> users { get; set; }
    }
}
