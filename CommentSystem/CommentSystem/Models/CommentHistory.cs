using CommentSystem.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommentSystem.Models.Entities
{
    public class CommentHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int LinkedToComment { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [ForeignKey("LinkedToComment")]
        public virtual Comment Comment { get; set; }
    }
}
