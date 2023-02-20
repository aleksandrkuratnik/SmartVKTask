using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class CommentResponse
    {
        [JsonProperty("response")]
        public Comment Response { get; set; }
    }
}
