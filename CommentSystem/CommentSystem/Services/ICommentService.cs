using CommentSystem.ApiController;

namespace CommentSystem.Services
{
    public interface ICommentService
    {
        void PostComment(PostCommentModel model, string posterId);
    }
}