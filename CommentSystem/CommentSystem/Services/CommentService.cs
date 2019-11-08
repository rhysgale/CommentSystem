using CommentSystem.ApiController;
using CommentSystem.Data;
using CommentSystem.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CommentSystem.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;

        public CommentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CommentModel PostComment(PostCommentModel model, string posterId)
        {
            var comment = new Comment()
            {
                CommenterId = posterId,
                CommentText = model.CommentText,
                FilmId = model.FilmId,
                CreateDateTime = DateTime.Now,
                ModifiedDateTime = DateTime.Now
            };

            var entity = _dbContext.Add(comment);
            _dbContext.SaveChanges();

            var entry = _dbContext.Comments.Include(x => x.User).First(x => x.CommentId == entity.Entity.CommentId);

            return new CommentModel()
            {
                CommentId = entry.CommentId,
                CommentText = entry.CommentText,
                CommenterEmail = entry.User.Email,
                CommenterId = entry.User.Id
            };
        }

        public void UpdateComment(UpdateCommentModel model, string posterId)
        {
            var comment = _dbContext.Comments.First(x => x.CommentId == model.CommentId);

            comment.CommentText = model.NewCommentText;
            comment.ModifiedDateTime = DateTime.Now;

            _dbContext.SaveChanges();
        }

        public void DeleteComment(DeleteCommentModel model, string posterId)
        {
            var comment = _dbContext.Comments.First(x => x.CommentId == model.CommentId);

            comment.IsDeleted = true;
            comment.ModifiedDateTime = DateTime.Now;

            _dbContext.SaveChanges();
        }
    }
}
