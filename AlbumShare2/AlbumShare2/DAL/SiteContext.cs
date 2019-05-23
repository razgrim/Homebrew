using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumShare2.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumShare2.DAL
{
    public class SiteContext : DbContext
    {

        public SiteContext(DbContextOptions<SiteContext> options) : base(options) {
            //initializeData();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumShare2.Models.Photo> Photos { get; set; }

        public void initializeData()
        {
            Users.Add(new User { name = "Test", email = "reuschtrevor@gmail.com", phone = "7168604523" });
            Users.Add(new User { name = "Trevor", email = "reuschtrevor@gmail.com", phone = "7168604563" }); 
        }
    }
}
