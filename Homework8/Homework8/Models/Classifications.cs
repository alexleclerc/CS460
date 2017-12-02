using System;
using System.Collections.Generic;

namespace Homework8.Models
{
    public partial class Classifications
    {
        public int ClassificationId { get; set; }
        public int ArtworkId { get; set; }
        public int GenreId { get; set; }

        public Artworks Artwork { get; set; }
        public Genres Genre { get; set; }
    }
}
