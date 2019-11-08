using CommentSystem.ApiController;
using CommentSystem.Data;
using CommentSystem.Models.Dto;

namespace CommentSystem.Services
{
    public interface ICommentService
    {
        CommentModel PostComment(PostCommentModel model, string posterId);
        void UpdateComment(UpdateCommentModel model, string posterId);
        void DeleteComment(DeleteCommentModel model, string posterId);
    }
}