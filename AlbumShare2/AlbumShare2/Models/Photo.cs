using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumShare2.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string tumbnailUrl { get; set; }
        public string url { get; set; }
        public int AlbumID { get; set; }
        public virtual Album Album { get; set; }
    }
}
