using Newtonsoft.Json;


namespace SMART_VK__API.Models
{
    internal class Post
    {
        [JsonProperty("post_id")]
        public int PostId { get; set; }
    }
}
