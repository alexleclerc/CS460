using System;
using System.Collections.Generic;

namespace Homework8.Models
{
    public partial class Artworks
    {
        public Artworks()
        {
            Classifications = new HashSet<Classifications>();
        }

        public int ArtworkId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }

        public Artists Artist { get; set; }
        public ICollection<Classifications> Classifications { get; set; }
    }
}
