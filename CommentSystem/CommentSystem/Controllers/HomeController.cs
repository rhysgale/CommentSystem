using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommentSystem.Models;
using CommentSystem.Services;
using CommentSystem.Models.ViewModel;

namespace CommentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmsService _filmsService;

        public HomeController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        public IActionResult Index()
        {
            var viewModel = new FilmListViewModel()
            {
                Films = _filmsService.GetFilmsList()
            };

            return View("FilmList", viewModel);
        }

        public IActionResult FilmOverview(int id)
        {
            var viewModel = new FilmViewModel()
            {
                Film = _filmsService.GetFilmById(id)
            };

            return View("Film", viewModel);
        }

        public IActionResult NewFilm()
        {
            return View();
        }
    }
}
