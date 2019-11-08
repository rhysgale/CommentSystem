using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommentSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentSystem.ApiController
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        // POST api/<controller>
        [HttpPost]
        public void PostComment([FromBody]PostCommentModel model)
        {
            _commentService.PostComment(model, "");
        }
    }
}
