using Aquality.Selenium.Browsers;
using RestSharp;
using SMART_VK__API.Models;
using SMART_VK__API.Utils;

namespace SMART_VK__API.API
{
    internal static class VkApi
    {
        private static readonly RestClient client = new(TestConfigManager.testConfig.ApiUrl);
        private static string token = TestConfigManager.testConfig.Token;
        private static string apiVersion = TestConfigManager.testConfig.ApiVersion;
        private static string ownerId = TestConfigManager.testConfig.UserId;

        private const string CreatePostMethod = "wall.post";
        private const string UploadPictureToServerMethod = "photos.getWallUploadServer";
        private const string SavePictureToWallMethod = "photos.saveWallPhoto";
        private const string EditPostMethod = "wall.edit";
        private const string CreateCommentMethod = "wall.createComment";
        private const string GetLikesMethod = "wall.getLikes";
        private const string DeletePostMethod = "wall.delete";

        private const string AccessToken = "access_token";
        private const string OwnerId = "owner_id";
        private const string Message = "message";
        private const string Version = "v";
        private const string Server = "server";
        private const string Hash = "hash";
        private const string Photo = "photo";
        private const string Attachment = "attachment";
        private const string PostId = "post_id";

        public static int CreatePost(string messageForPost)
        {
            RestRequest request = new RestRequest(CreatePostMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(OwnerId, ownerId)
                .AddParameter(Message, messageForPost)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
            AqualityServices.Logger.Info("Start first query " + response.Content);
            Post postFromApi = ModelDeserializer.DeserializeModel<PostResponse>(response).Response;
            int postIdFromApi = postFromApi.PostId;
            return postIdFromApi;
        }

        public static string GetUploadServer()
        {
            RestRequest request = new RestRequest(UploadPictureToServerMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
            UploadInfo uploadResponse = ModelDeserializer.DeserializeModel<UploadServerResponse>(response).Response;
            return uploadResponse.UploadUrl;
        }

        public static string SaveImage(ImageResponse image)
        {
            RestRequest request = new RestRequest(SavePictureToWallMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(OwnerId, ownerId)
                .AddParameter(Server, image.Server.ToString())
                .AddParameter(Hash, image.Hash)
                .AddParameter(Photo, image.Photo)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
            SavedImageResponse savedImageResponse = ModelDeserializer.DeserializeModel<SavedImageResponse>(response);
            Console.WriteLine("saveimage " + response.Content);
            return savedImageResponse.Response[0].Id.ToString();
        }

        public static string EditPostAndUploadPicture(string messageForEdit, string postId,
            string userId, string savePhotoId)
        {
            var photoId = CombinePhotoIdParameter(userId, savePhotoId);
            RestRequest request = new RestRequest(EditPostMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(OwnerId, ownerId)
                .AddParameter(PostId, postId)
                .AddParameter(Message, messageForEdit)
                .AddParameter(Attachment, photoId)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
            AqualityServices.Logger.Info("editpostupload " + response.Content);
            return photoId;
        }

        private static string CombinePhotoIdParameter(string userId, string savePhotoId)
        {
            string photoId = "photo" + userId + "_" + savePhotoId;
            return photoId;
        }

        public static int CreateComment(string messageForPost, string postId)
        {
            RestRequest request = new RestRequest(CreateCommentMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(PostId, postId)
                .AddParameter(OwnerId, ownerId)
                .AddParameter(Message, messageForPost)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
            Comment commentFromApi = ModelDeserializer.DeserializeModel<CommentResponse>(response).Response;
            int commentIdFromApi = commentFromApi.CommentId;
            return commentIdFromApi;
        }

        public static int CheckLikedUser(string postId)
        {
            RestRequest request = new RestRequest(GetLikesMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(PostId, postId)
                .AddParameter(OwnerId, ownerId)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
            LikesResponse likedUsers = ModelDeserializer.DeserializeModel<LikesResponse>(response);
            AqualityServices.Logger.Info("Like response content= " + response.Content);
            int userIdWhoLiked = likedUsers.Response.users[0].Uid;
            return userIdWhoLiked;
        }

        public static void DeletePost(string postId)
        {
            RestRequest request = new RestRequest(DeletePostMethod, Method.Post);
            request.AddParameter(AccessToken, token)
                .AddParameter(PostId, postId)
                .AddParameter(OwnerId, ownerId)
                .AddParameter(Version, apiVersion);
            RestResponse response = client.Post(request);
        }
    }
}
