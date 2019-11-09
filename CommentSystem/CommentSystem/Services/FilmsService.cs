using CommentSystem.ApiController;
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
                                           CommentText = x.CommentText,
                                           CreateDateTime = x.CreateDateTime,
                                       }).OrderByDescending(x => x.CreateDateTime).ToList()
                                   }).ToList();
        }

        public FilmModel GetFilmById(int id)
        {
            var film = _dbContext.Films.Include(x => x.Comments).First(x => x.FilmId == id);

            var comments = _dbContext.Comments.Include(x => x.User)
                                            .Include(x => x.RevisionHistory)
                                            .Where(x => x.FilmId == id && x.IsDeleted == false)
                                            .ToList();

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
                    CommenterEmail = x.User.Email,
                    CreateDateTime = x.CreateDateTime,
                    CommentHistory = x.RevisionHistory.Select(y => new CommentHistoryModel()
                    {
                        CommentText = y.Text,
                        CreateDateTime = y.CreatedDateTime
                    }).ToList()
                })
                .OrderByDescending(x => x.CreateDateTime).ToList()
            };
        }

        public FilmModel AddFilm(NewFilmModel model)
        {
            var film = new Film()
            {
                FilmDescription = model.FilmDescription,
                FilmTitle = model.FilmTitle
            };

            var filmentity = _dbContext.Films.Add(film);
            _dbContext.SaveChanges();

            return new FilmModel()
            {
                FilmId = filmentity.Entity.FilmId,
                FilmDescription = filmentity.Entity.FilmDescription,
                FilmTitle = filmentity.Entity.FilmTitle,
            };
        }
    }
}


