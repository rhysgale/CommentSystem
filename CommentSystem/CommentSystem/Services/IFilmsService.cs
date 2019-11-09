using CommentSystem.ApiController;
using CommentSystem.Models.Dto;
using System.Collections.Generic;

namespace CommentSystem.Services
{
    public interface IFilmsService
    {
        List<FilmModel> GetFilmsList();

        FilmModel GetFilmById(int id);

        FilmModel AddFilm(NewFilmModel model);
    }
}