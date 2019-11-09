using System;

namespace CommentSystem.Models.Dto
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string CommenterId { get; set; }
        public string CommenterEmail { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}