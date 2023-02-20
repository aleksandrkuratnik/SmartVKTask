using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using SMART_VK__API.Utils;

namespace SMART_VK__API.PageObjects
{
    internal class PostForm : Form
    {
        private ILabel postsText(int postsId, string userId) => ElementFactory.GetLabel(By.XPath($"//*[@id='wpt{userId}_{postsId}']"), nameof(postsText));
        private ILabel postsAuthor(int postsId, string userId) => ElementFactory.GetLabel(By.XPath($"//div[@id='post{userId}_{postsId}']//a[@class='author']"), nameof(postsAuthor));
        private static ILabel commentAuthor(string userId, int commentId) => ElementFactory.GetLabel(By.XPath($"//div[@id='post{userId}_{commentId}']//a[@class='author']"), nameof(commentAuthor));
        private static IButton showComments(string userId, int postsId) => ElementFactory.GetButton(By.XPath($"//*[@id='replies{userId}_{postsId}']//span[@class='js-replies_next_label']"), nameof(showComments));
        private static ILabel photo(string userId, int postsId) => ElementFactory.GetLabel(By.XPath($"//div[@id='wpt{userId}_{postsId}']//a[@href]"), nameof(photo));
        private static IButton likeBtn(string userId, int postsId) => ElementFactory.GetButton(By.XPath($"//div[@class='like_wrap _like_wall{userId}_{postsId} ']//div[@class='PostButtonReactions__icon ']//*[name()='svg']"), nameof(likeBtn));
        private static IButton likeBtnWithValue(string userId, int postsId) => ElementFactory.GetButton(By.XPath($"//div[contains(@class,'like_wrap _like_wall{userId}_{postsId}')]//div[@aria-label='1']"), nameof(likeBtn));

        public PostForm(int postsId, string userId) : base(By.XPath($"//*[@id='post{userId}_{postsId}']"), "Post")
        {
        }

        public PostForm() : base(By.XPath("//div[contains(@class, '_post post page_block all own post--withPostBottomAction  post--with-likes deep_active Post--redesign')]"), "adfkl")
        {

        }


        public string GetPostsText(int postsId, string userId)
        {
            return postsText(postsId, userId).Text;
        }

        public string GetPostsAuthor(int postsId, string userId)
        {
            string authorIdHref = postsAuthor(postsId, userId).GetAttribute("href");
            string authorId = Util.GetTrimString(authorIdHref, "id");
            return authorId;
        }

        public string GetCommentAuthor(string userId, int commentId, int postsId)
        {
            if (showComments(userId, postsId).State.WaitForDisplayed())
                showComments(userId, postsId).Click();
            string authorIdHref = commentAuthor(userId, commentId).GetAttribute("href");
            string authorId = Util.GetTrimString(authorIdHref, "id");
            return authorId;
        }

        public void LikePost(string userId, int postId)
        {
            likeBtn(userId, postId).ClickAndWait();
        }

        public string GetPictureId(int postsId, string userId)
        {
            string photoId = photo(userId, postsId).GetAttribute("href");
            string photoIdNew = Util.GetTrimString(photoId, "com/");
            return photoIdNew;
        }
    }
}
