using Newtonsoft.Json;


namespace SMART_VK__API.Models
{
    internal class PostResponse
    {
        [JsonProperty("response")]
        public Post Response { get; set; }
    }
}
