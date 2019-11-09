using CommentSystem.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CommentSystem.ApiController
{
    [Route("api/[controller]")]
    public class FilmsController : Controller
    {
        private readonly IFilmsService _filmsService;

        public FilmsController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]NewFilmModel model)
        {
            _filmsService.AddFilm(model);
        }
    }
}
