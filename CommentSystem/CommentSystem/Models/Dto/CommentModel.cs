using System;
using System.Collections.Generic;

namespace CommentSystem.Models.Dto
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public string CommenterId { get; set; }
        public string CommenterEmail { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateDateTime { get; set; }
        public List<CommentHistoryModel> CommentHistory { get; set; }
    }
}