using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Models
{
    public class BabyUser : IdentityUser
    {
        public Guid BabyId { get; set; }
        public string OtherOwnerId1 { get; set; }
        public string OtherOwnerId2 { get; set; }
    }
}
