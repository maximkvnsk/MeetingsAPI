﻿using System;
using System.Collections.Generic;

namespace Meetings.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
