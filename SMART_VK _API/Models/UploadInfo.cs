using Newtonsoft.Json;


namespace SMART_VK__API.Models
{
    internal class UploadInfo
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        [JsonProperty("upload_url")]
        public string UploadUrl { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}
