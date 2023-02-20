using Aquality.Selenium.Browsers;
using NUnit.Framework;
using SMART_VK__API.API;
using SMART_VK__API.Models;
using SMART_VK__API.PageObjects;

using SMART_VK__API.Utils;

namespace SMART_VK__API.Tests
{
    public class Tests : BaseTest
    {
        private readonly string userId = TestConfigManager.testConfig.UserId;

        [Test]
        public void VkApiTest()
        {
            welcomePage.InputLoginAndClickSingInButton();
            enterPasswordPage.EnterPasswordAndContinue();
            newsPage.ClickMyProfileButton();

            string expectedTextForPost = RandomString.GetGeneratedRandomString();
            int postIdFromApi = VkApi.CreatePost(expectedTextForPost);
            PostForm postFormUi = new PostForm(postIdFromApi, userId);
            string postTextFromUi = postFormUi.GetPostsText(postIdFromApi, userId);
            string postAuthorIdFromUi = postFormUi.GetPostsAuthor(postIdFromApi, userId);
            Assert.Multiple(() =>
            {
                Assert.That(expectedTextForPost, Is.EqualTo(postTextFromUi), "Text doesn't match");
                Assert.That(userId, Is.EqualTo(postAuthorIdFromUi), "Author doesn't match");
            });

            string editedMessageForPost = RandomString.GetGeneratedRandomString();
            string serverUploadUrl = VkApi.GetUploadServer();
            ImageResponse imageResponse = Api.UploadPicture(serverUploadUrl);
            string savedImageId = VkApi.SaveImage(imageResponse);

            string photoId = VkApi.EditPostAndUploadPicture(editedMessageForPost,
                  postIdFromApi.ToString(), userId, savedImageId);
            AqualityServices.Logger.Info("PhotoId = " + photoId);
            string postTextAfterChangingFromUi = postFormUi.GetPostsText(postIdFromApi, userId);
            string photoIdFromUi = postFormUi.GetPictureId(postIdFromApi, userId);
            Assert.Multiple(() =>
            {
                Assert.That(expectedTextForPost, Is.Not.EqualTo(postTextAfterChangingFromUi), "Text wasn't changed");
                Assert.That(photoId, Is.EqualTo(photoIdFromUi), "Photo Id wasn't equal");
            });

            AqualityServices.Logger.Info("Start comment step");
            string comment = RandomString.GetGeneratedRandomString();
            int commentIdFromApi = VkApi.CreateComment(comment, postIdFromApi.ToString());
            AqualityServices.Logger.Info("CommentId= " + commentIdFromApi.ToString());
            postFormUi.State.WaitForDisplayed();
            string commentAuthorIdFromUi = postFormUi.GetCommentAuthor(userId, commentIdFromApi, postIdFromApi);
            Assert.That(userId, Is.EqualTo(commentAuthorIdFromUi), "Comment Author doesn't match");

            AqualityServices.Logger.Info("startingLikesStep");
            postFormUi.LikePost(userId, postIdFromApi);
            int userIdWhoLikedPost = VkApi.CheckLikedUser(postIdFromApi.ToString());
            AqualityServices.Logger.Info("userIdWhoLikedPost= " + userIdWhoLikedPost.ToString());
            Assert.That(userId, Is.EqualTo(userIdWhoLikedPost.ToString()), "User who liked doesn't match");

            AqualityServices.Logger.Info("starting deletingPost step");
            VkApi.DeletePost(postIdFromApi.ToString());
            postFormUi.State.WaitForNotDisplayed();
            Assert.IsFalse(postFormUi.State.IsDisplayed, "Post wasn't delete");
        }
    }
}
