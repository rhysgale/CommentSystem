using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentSystem.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int FilmId { get; set; }
        public string CommentText { get; set; }
        public string CommenterId { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film LinkedFilm { get; set; }
        [ForeignKey("CommenterId")]
        public virtual IdentityUser User { get; set; }
    }
}