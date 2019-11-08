using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommentSystem.Data
{
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public string FilmDescription { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}