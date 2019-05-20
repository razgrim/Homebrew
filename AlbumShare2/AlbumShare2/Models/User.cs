using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumShare2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phonenum { get; set; }
        public string address { get; set; }

        public virtual ICollection<Post> posts { get; set; }
        public virtual ICollection<Album> albums { get; set; }

    }
}
