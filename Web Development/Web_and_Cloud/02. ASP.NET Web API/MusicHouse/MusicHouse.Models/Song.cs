using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicHouse.Models
{
    public class Song
    {
        private ICollection<Artist> artists;

        public int SongId { get; set; }
        public string Title { get; set; }
        public virtual DateTime? Year { get; set; }
        public string Genre { get; set; }
        public int ArtistId { get; set; }
        public virtual Album Album { get; set; }

        //public Song()
        //{
        //    this.artists = new HashSet<Artist>();
        //}

        //public virtual IList<Artist> Artists{ get; set; }
    }
}
