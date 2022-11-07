using System;
using System.Collections.Generic;

#nullable disable

namespace BookClubAPI.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string CommentMessage { get; set; }
    }
}
