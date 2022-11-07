using System;
using System.Collections.Generic;

#nullable disable

namespace BookClubAPI.Models
{
    public partial class UsersLikesDislike
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public bool LikeDislike { get; set; }
    }
}
