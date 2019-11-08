using CommentSystem.ApiController;
using CommentSystem.Data;
using System;

namespace CommentSystem.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Comment PostComment(PostCommentModel model, string posterId)
        {
            var comment = new Comment()
            {
                CommenterId = posterId,
                CommentText = model.CommentText,
                FilmId = model.FilmId,
                CreateDateTime = DateTime.Now,
                ModifiedDateTime = DateTime.Now
            };

            _dbContext.Add(comment);
            _dbContext.SaveChanges();

            return comment;
        }

        public void UpdateComment(UpdateCommentModel model, string posterId)
        {

        }
    }
}
