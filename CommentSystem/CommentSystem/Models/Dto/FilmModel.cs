using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentSystem.Models.Dto
{
    public class FilmModel
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public string FilmDescription { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
