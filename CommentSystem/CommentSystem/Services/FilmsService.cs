using CommentSystem.Data;
using CommentSystem.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CommentSystem.Services
{
    public class FilmsService : IFilmsService
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmsService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<FilmModel> GetFilmsList()
        {
            return _dbContext.Films.Include(x => x.Comments)
                                   .Select(x => new FilmModel()
                                   {
                                       FilmDescription = x.FilmDescription,
                                       FilmId = x.FilmId,
                                       FilmTitle = x.FilmTitle,
                                       Comments = x.Comments.Where(y => y.IsDeleted == false).Select(x => new CommentModel()
                                       {
                                           CommenterId = x.CommenterId,
                                           CommentId = x.CommentId,
                                           CommentText = x.CommentText
                                       })
                                       .ToList()
                                   }).ToList();
        }

        public FilmModel GetFilmById(int id)
        {
            var film = _dbContext.Films.Include(x => x.Comments).First(x => x.FilmId == id);
            var comments = _dbContext.Comments.Include(x => x.User).Where(x => x.FilmId == id);

            return new FilmModel
            {
                FilmDescription = film.FilmDescription,
                FilmId = film.FilmId,
                FilmTitle = film.FilmTitle,
                Comments = comments.Where(y => y.IsDeleted == false).Select(x => new CommentModel()
                {
                    CommenterId = x.CommenterId,
                    CommentId = x.CommentId,
                    CommentText = x.CommentText,
                    CommenterEmail = x.User.Email
                }).ToList()
            };
        }
    }
}


