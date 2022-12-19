using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(): base("DefaultConnection")
        {

        }
        public DbSet<category> categories { get; set; }
        public DbSet<book> books { get; set; }
        
    }
}