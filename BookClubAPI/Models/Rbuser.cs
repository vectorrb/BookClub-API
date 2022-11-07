using System;
using System.Collections.Generic;

#nullable disable

namespace BookClubAPI.Models
{
    public partial class Rbuser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Hobbies { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
