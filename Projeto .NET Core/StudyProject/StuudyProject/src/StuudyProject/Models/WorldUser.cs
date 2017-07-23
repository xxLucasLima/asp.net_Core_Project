using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace StuudyProject.Models
{
    public class WorldUser: IdentityUser
    {
        public DateTime FirstTrip { get; set; }

    }
}