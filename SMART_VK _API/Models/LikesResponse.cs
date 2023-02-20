using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class LikesResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }
}
