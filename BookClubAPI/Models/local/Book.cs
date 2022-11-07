using System;
using System.Collections.Generic;

#nullable disable

namespace BookClubAPI.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
        public string BookImageUrl { get; set; }
        public string Genre { get; set; }
        public string Subgenre { get; set; }
        public bool? WantToRead { get; set; }
        public bool? HaveRead { get; set; }
        public string Description { get; set; }
    }
}
