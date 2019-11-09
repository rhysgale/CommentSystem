using CommentSystem.ApiController;
using CommentSystem.Data;
using CommentSystem.Models.Dto;
using CommentSystem.Models.Entities;
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
                CreateDateTime = DateTime.Now
            };

            var entity = _dbContext.Add(comment);
            _dbContext.SaveChanges();

            var entry = _dbContext.Comments.Include(x => x.User).First(x => x.CommentId == entity.Entity.CommentId);

            return new CommentModel()
            {
                CommentId = entry.CommentId,
                CommentText = entry.CommentText,
                CommenterEmail = entry.User.Email,
                CommenterId = entry.User.Id,
                CreateDateTime = entry.CreateDateTime
            };
        }

        public CommentModel UpdateComment(UpdateCommentModel model, string posterId)
        {
            var comment = _dbContext.Comments.Include(x => x.User).First(x => x.CommentId == model.CommentId);

            var commentHistory = new CommentHistory()
            {
                CreatedDateTime = comment.CreateDateTime,
                LinkedToComment = comment.CommentId,
                Text = comment.CommentText
            };

            comment.CommentText = model.CommentText;
            comment.CreateDateTime = DateTime.Now;

            _dbContext.CommentsHistory.Add(commentHistory);
            _dbContext.SaveChanges();

            return new CommentModel()
            {
                CommenterEmail = comment.User.Email,
                CommenterId = comment.CommenterId,
                CommentText = comment.CommentText,
                CreateDateTime = comment.CreateDateTime,
                CommentId = comment.CommentId,
                CommentHistory = _dbContext.CommentsHistory.Where(x => x.LinkedToComment == comment.CommentId).Select(y => new CommentHistoryModel() { 
                    CommentText = y.Text,
                    CreateDateTime = y.CreatedDateTime
                }).ToList()
            };
        }

        public void DeleteComment(DeleteCommentModel model, string posterId)
        {
            var comment = _dbContext.Comments.First(x => x.CommentId == model.CommentId);

            comment.IsDeleted = true;

            _dbContext.SaveChanges();
        }
    }
}
