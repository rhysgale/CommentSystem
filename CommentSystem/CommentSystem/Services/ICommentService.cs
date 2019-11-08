using CommentSystem.ApiController;
using CommentSystem.Data;

namespace CommentSystem.Services
{
    public interface ICommentService
    {
        Comment PostComment(PostCommentModel model, string posterId);
        Comment UpdateComment(UpdateCommentModel model, string posterId);
    }
}