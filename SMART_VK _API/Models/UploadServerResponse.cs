using Newtonsoft.Json;

namespace SMART_VK__API.Models
{
    internal class UploadServerResponse
    {
        [JsonProperty("response")]
        public UploadInfo Response { get; set; }
    }
}
