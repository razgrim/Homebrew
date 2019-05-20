using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumShare2.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
