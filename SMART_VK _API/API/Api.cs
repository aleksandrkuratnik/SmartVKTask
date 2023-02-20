using RestSharp;
using SMART_VK__API.Constans;
using SMART_VK__API.Models;
using SMART_VK__API.Utils;

namespace SMART_VK__API.API
{
    internal static class Api
    {
        public static ImageResponse UploadPicture(string uploadUrl)
        {
            RestClient clientForUpload = new RestClient(uploadUrl);
            RestRequest request = new RestRequest();
            clientForUpload.AddDefaultHeader(KnownHeaders.ContentType, "multipart/form-data");
            request.AddFile("photo", ConstantPath.pathToImage);
            RestResponse editPostResponse = clientForUpload.Post(request);
            ImageResponse imageResponse = ModelDeserializer.DeserializeModel<ImageResponse>(editPostResponse);
            return imageResponse;
        }
    }
}
