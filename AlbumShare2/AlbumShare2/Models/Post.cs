using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumShare2.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string body { get; set; }
    }
}
