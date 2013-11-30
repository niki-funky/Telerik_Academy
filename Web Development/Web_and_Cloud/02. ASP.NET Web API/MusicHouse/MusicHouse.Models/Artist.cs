using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicHouse.Models
{
    public class Artist
    {
        private ICollection<Album> albums;
        private ICollection<Song> songs;

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual DateTime? DateOfBirth { get; set; }

        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs = new HashSet<Song>();
        }

        public virtual IList<Album> Albums { get; set; }
        public virtual IList<Song> Songs { get; set; }
    }
}
