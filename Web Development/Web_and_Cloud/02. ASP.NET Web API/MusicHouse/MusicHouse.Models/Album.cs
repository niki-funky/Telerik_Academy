using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicHouse.Models
{
    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public virtual DateTime? ReleaseDate { get; set; }
        public string Producer { get; set; }

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        public virtual IList<Artist> Artists { get; set; }
        public virtual IList<Song> Songs { get; set; }
    }
}
