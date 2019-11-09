using System;

namespace CommentSystem.Models.Dto
{
    public class CommentHistoryModel
    {
        public DateTime CreateDateTime { get; set; }
        public string CommentText { get; set; }
    }
}