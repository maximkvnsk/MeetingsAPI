using System;
using System.Collections.Generic;

namespace Meetings.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsBanned { get; set; }
        public int? ProfileId { get; set; }
        public int RoleId { get; set; }

        public  Role Role { get; set; }
        public Profile Profile { get; set; }
    }
}
