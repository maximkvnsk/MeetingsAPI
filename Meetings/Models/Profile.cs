using System;
using System.Collections.Generic;

namespace Meetings.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] ProfPicture { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
