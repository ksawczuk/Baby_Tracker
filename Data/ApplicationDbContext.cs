using Baby_Tracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baby_Tracker.Data
{
    // This class allows the connection and mapping of the database to instances of Baby class.

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    
        //The properties below creates the mapping to a list of Babies, Sleeps and Feeds which are instances of the Baby, Sleep and Feed class.
        //Other classes pertinent to Baby (such as Sleep, Feed etc) are mapped via list properties in the Baby class.
        public DbSet<Baby> Baby { get; set; }
        public DbSet<Sleep> Sleep { get; set; }
        public DbSet<Feed> Feed { get; set; }
         
    }
}
