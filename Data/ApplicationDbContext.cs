using Baby_Tracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Baby_Tracker.Data
{
    // This class allows the connection and mapping of the database to instances of Baby class.

    public class ApplicationDbContext : DbContext
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbSet<Baby> Baby { get; set; }
        public DbSet<Sleep> Sleep { get; set; }
        public DbSet<Feed> Feed { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        { 
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // The GlobalQueryFilter below will ensure that db access for baby_db is limited to babies that are associated with their rightful owners.
            // Need to test this out somehow.
            builder.Entity<Baby>()
                .HasQueryFilter(
                    baby_cx => (baby_cx.OwnerId1 == _httpContextAccessor.HttpContext
                    .User.FindFirstValue(ClaimTypes.NameIdentifier)) | (baby_cx.OwnerId2 == _httpContextAccessor.HttpContext
                    .User.FindFirstValue(ClaimTypes.NameIdentifier)) | (baby_cx.OwnerId3 == _httpContextAccessor.HttpContext
                    .User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
    }
}
